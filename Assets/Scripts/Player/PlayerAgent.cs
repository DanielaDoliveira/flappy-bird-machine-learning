using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class PlayerAgent : Agent
{
    
    [SerializeField] private Rigidbody2D jogadorRb;
    [SerializeField] private Player _player;
    [SerializeField] private Transform buracoMaisProximo;
    [SerializeField] private Transform segundoBuracoMaisProximo;
    private float tempoMaximoDeVida = 10f;
    private float tempoAtual = 0f;
    private float jumpForce = 7f;
    private void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating(nameof(UpdateBuracoMaisProximo), 0f, 0.5f);
    }
    


    private void Awake()
    {
        jogadorRb = GetComponent<Rigidbody2D>();
        var requester = GetComponent<DecisionRequester>();
        if (requester == null)
        {
            requester = gameObject.AddComponent<DecisionRequester>();
        }
        requester.DecisionPeriod = 3;
    }
    public override void OnEpisodeBegin()
    {
        tempoAtual = 0f;
        jogadorRb.velocity = Vector2.zero;
        jogadorRb.position = new Vector3(-15.43f, UnityEngine.Random.Range(-1.88f, 1.88f));


    }

    private void FixedUpdate()
    {
        tempoAtual += Time.deltaTime;

        if (tempoAtual > tempoMaximoDeVida)
        {
            EndEpisode();
            tempoAtual = 0f;
        }
    }


    private void Update()
    {
        if (buracoMaisProximo != null)
        {
            Debug.DrawLine(jogadorRb.position, buracoMaisProximo.position, Color.red);
        }
    }

    private void UpdateBuracoMaisProximo()
    {
        GameObject[] buracos = GameObject.FindGameObjectsWithTag("POINT");

        float menorDistancia = float.MaxValue;
        float segundaMenorDistancia = float.MaxValue;
        Transform maisProximo = null;
        Transform segundoMaisProximo = null;

        foreach (var buraco in buracos)
        {
            float dist = buraco.transform.position.x - jogadorRb.position.x;
            if (dist > 0)
            {
                if (dist < menorDistancia)
                {
                    segundaMenorDistancia = menorDistancia;
                    segundoMaisProximo = maisProximo;

                    menorDistancia = dist;
                    maisProximo = buraco.transform;
                }
                else if (dist < segundaMenorDistancia)
                {
                    segundaMenorDistancia = dist;
                    segundoMaisProximo = buraco.transform;
                }
            }
        }

        buracoMaisProximo = maisProximo;
        segundoBuracoMaisProximo = segundoMaisProximo;
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        if (buracoMaisProximo == null)
        {
          
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
        }
        else
        {
            sensor.AddObservation(Mathf.Clamp((buracoMaisProximo.position.x - jogadorRb.position.x) / 20f, -1f, 1f));
            sensor.AddObservation(Mathf.Clamp((buracoMaisProximo.position.y - jogadorRb.position.y) / 10f, -1f, 1f));
            sensor.AddObservation(Mathf.Clamp(jogadorRb.position.y / 10f, -1f, 1f));
            sensor.AddObservation(Mathf.Clamp(jogadorRb.velocity.y / 10f, -1f, 1f));
        }

        if (segundoBuracoMaisProximo != null)
        {
            sensor.AddObservation(Mathf.Clamp((segundoBuracoMaisProximo.position.x - jogadorRb.position.x) / 20f, -1f, 1f));
            sensor.AddObservation(Mathf.Clamp((segundoBuracoMaisProximo.position.y - jogadorRb.position.y) / 10f, -1f, 1f));
        }
        else
        {
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
        }

        HoleDetector();
    }

    public void HoleDetector()
    {
        if (buracoMaisProximo != null)
        {
            float distX = buracoMaisProximo.position.x - jogadorRb.position.x;
            float deltaY = Mathf.Abs(jogadorRb.position.y - buracoMaisProximo.position.y);

            if (distX < 5f)
            {
                float alinhamento = Mathf.Clamp01(1 - deltaY);
                AddReward(alinhamento * 0.05f);
            }

            if (deltaY > 1.5f) AddReward(-0.02f);
            if (deltaY > 2.5f) AddReward(-0.05f);
        }
    }

  

    public override void OnActionReceived(ActionBuffers actions)
    {
      int pular = actions.DiscreteActions[0];
      AddReward(0.0001f); // recompensa por sobreviver

      if (pular == 1)
      {
          jogadorRb.velocity = Vector2.zero;
          jogadorRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
       
      }
        
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetMouseButtonDown(0) ? 1 : 0;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstáculo"))
        {
            SetReward(-3f);
            EndEpisode();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("POINT"))
        {
            AddReward(+1f); // passou por um cano!
        }
    }
}
