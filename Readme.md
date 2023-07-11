# Rhitmo Estacionamento

## O que a solução faz?
A Solução é capaz de incluir veículos em vagas de estacionamento, levando em consideração alguns pontos:
- O estacionamento pode acomodar motos, carros e vans;
- O estacionamento possui vagas que comportam motos, carros e vagas grandes para vans;
- Uma moto pode estacionar em qualquer uma das vagas;
- Um carro pode estacionar em uma única vaga para carro ou em uma vaga grande;
- Uma van pode estacionarem uma vaga grande, ou nas vagas de carro, a mesma ocupando 3 vagas.

## Arquitetura do Projeto
A solução foi feita em uma API em .NET 7, foi estruturada de forma simples, sendo separadas as responsabilidades por camada.
A API está documentada com Swagger.
O sistema tem implementado dois endpoints: um para retornar a quantidade de vagas e o outro para fazer a reserva da mesma.

## Execução do código
Para executar o teste, pode ser utilizado o próprio Swagger, inicializando o projeto.

## Endpoint - Obter Vagas
O endpoint obter-vagas é responsável por retornar os indicadores das vagas do estacionamento. Essas informações são retornadas no formato JSON e obedecem os critérios estabelecidos para a construção da aplicação.

```json
{
  "disponivel": 30,
  "total": 30,
  "capacidade": 1,
  "capacidadeDescricao": "Total",
  "classificacao": [
    {
      "tipoVaga": 1,
      "tipoVagaDescricao": "Moto",
      "total": 10,
      "reservado": 0,
      "disponivel": 10
    },
    {
      "tipoVaga": 2,
      "tipoVagaDescricao": "Carro",
      "total": 10,
      "reservado": 0,
      "disponivel": 10
    },
    {
      "tipoVaga": 3,
      "tipoVagaDescricao": "Grande",
      "total": 10,
      "reservado": 0,
      "disponivel": 10
    }
  ],
  "ocupacao": []
}
```

**Glossário:**
| Campo  | Descrição |
| :-------------------: | :--------------------------------------------------------------------------------------------------- |
| "disponivel"  | quantidade de vagas que ainda estão disponíveis no estacionamento; |
| "total"  | quantidade total de vagas no estacionamento;  |
| "capacidade"  | indicador responsável por mostrar a capacidade atual do estacionamento (indisponível, parcial e total);   |
| "capacidadeDescricao"  | descrição do indicador "capacidade";   |
| "classificacao"  | objeto responsavel por retornar os indicadores por tipo de vaga, nele conseguimos visualizar a quantidade de vagas - disponiveis, reservadas e o total por tipo;   |
| "tipoVaga"  | indicador responsavel por mostrar o tipo da vaga utilizada (moto, carro, grande);   |
| "tipoVagaDescricao"  | descrição do indicador "tipoVaga";   |
| "reservado"  | indicador responsavel por mostrar a quantidade de vagas reservadas no esta   |

Ao ser feito uma reserva é retornado em formato JSON, as informações sobre o veiculo reservado na vaga:
```json
"ocupacao": [
    {
      "dataReserva": "2023-07-11T16:55:35.6376874-03:00",
      "tipoVeiculo": 1,
      "tipoVeiculoDescricao": "Carro",
      "tipoVaga": 2,
      "tipoVagaDescricao": "Carro",
      "quantidade": 1
    }
  ]
```

**Glossário:**
- "dataReserva" - indicador que retorna a data e horário que foi efetuada a reserva da vaga;
- "tipoVeiculo" - retorna o indicador do tipo de veículo reservada na vaga;
- "tipoVeiculoDescricao" - descrição do indicador tipoVeiculo;
- "tipoVaga" - indicador responsavel por mostrar o tipo da vaga utilizada (moto, carro, grande);
- "tipoVagaDescricao" - descrição do indicador "tipoVaga";
- "quantidade" - indicador que mostra a quantidade de vagas que foi ocupada na reserva.

## Endpoint - Reservar vaga
O endpoint reservar é responsável por cadastrar uma reserva de um tipo específico de veiculo, sendo passado em formato JSON no corpo da requisição. Seguindo os critérios estabelecidos é possivel fazer a reserva de 3 tipos de veiculos:

Payload:
```json
{
  "tipoVeiculo": 1
}
```

Tipos de Veiculo:
1 - Carro
2 - Moto
3 - Van

## Mensagens de retorno da aplicação

Caso a reserva seja feita com sucesso:
```json
{
  "success": true,
  "data": null,
  "message": "Reserva realizada com sucesso."
}
```

Caso tente adicionar um veiculo que não exista:
```json
{
  "success": false,
  "data": null,
  "message": "Tipo do veículo não corresponde."
}
```

Caso não tenha mais vagas:
```json

{
  "success": true,
  "data": null,
  "message": "Reserva não foi realizada."
}
```

A aplicação está configurada para iniciar com uma quantidade total de 30 vagas, sendo 10 de moto, 10 de carro e 10 vagas grandes. Esta configuração está mockada dentro da classe do repositório.

Lembrando que os métodos foram construidos de modo estático para que a dinâmica entre consultar as vagas e realizar o cadastro funcione de forma perfeita, já que não há conexão com o banco de dados.
