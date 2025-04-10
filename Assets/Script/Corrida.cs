using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Jogo();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Jogo()
    {
        int jogador1 = 0, jogador2 = 0;                
        int pontuacaoMin = 20;
        int dado = 0;

        while (jogador1 < pontuacaoMin && jogador2 < pontuacaoMin)
        {
            dado = Random.Range(1, 6);

            jogador1 += dado;

            print($"Jogador1 lançou o dado e obteve {dado} pontos!");
            print($"Jogador1 está com {jogador1} pontos!");

            if (jogador1 >= 20)
                print($"Venceu o jogador1, com {jogador1} pontos! ");
            else
            {

                dado = Random.Range(1, 6);

                jogador2 += dado;

                print($"Jogador2 lançou o dado e obteve {dado} pontos!");
                print($"Jogador2 está com {jogador2} pontos!");

                if (jogador2 >= 20)
                    print($"Venceu o jogador2, com {jogador2} pontos! ");
            }
        }



    }
}
