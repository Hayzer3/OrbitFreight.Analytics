# OrbiFreight Analytics API - Global Solution 2026/1

**Disciplina:** Advanced Business Development with .NET  
**Instituicao:** FIAP - 2TDS  
**Projeto:** OrbiFreight Analytics

---

## Sobre o Projeto

O **OrbiFreight** e uma plataforma de monitoramento inteligente para transporte de cargas pereciveis e farmaceuticas com alta sensibilidade termica.

A API **OrbiFreight Analytics** atua como o modulo analitico e financeiro do ecossistema, consolidando dados operacionais da frota, ocorrencias criticas e leituras de sensores para gerar indicadores de risco, perdas estimadas e historico auditavel de alertas.

O projeto foi desenvolvido em **ASP.NET Core 8**, com **Entity Framework Core** e banco de dados **Oracle 19c**, seguindo uma abordagem voltada para leitura, agregacao e analise de dados.

---

## Objetivo da API

A API tem como objetivo transformar eventos logisticos e leituras de telemetria em informacoes gerenciais para apoio a tomada de decisao.

Entre as principais analises realizadas estao:

- resumo diario de cargas, alertas e prejuizos;
- estimativa financeira de perdas por tipo de produto;
- ranking de rotas com maior volume de ocorrencias;
- historico paginado de alertas registrados;
- leitura estruturada das entidades relacionais do banco Oracle.

---

## Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Oracle 19c**
- **Swagger / OpenAPI**
- **LINQ**
- **C#**

---

## Arquitetura do Sistema

A aplicacao foi organizada com foco em responsabilidade unica, baixo acoplamento e leitura eficiente de dados analiticos.

### Camadas do Projeto

- **Controllers:** expoem os endpoints REST e coordenam as requisicoes HTTP.
- **Data:** contem o `AppDbContext`, responsavel pela conexao com o Oracle e pelo mapeamento das entidades.
- **DTOs:** definem os objetos de transferencia usados nas respostas da API.
- **Models:** representam as entidades relacionais do banco de dados.
- **Migrations:** armazenam o historico de versionamento fisico do banco.

### Decisao Arquitetural

Como o microsservico possui foco em relatorios, agregacoes e consultas analiticas, os controllers acessam o contexto de dados por meio de consultas LINQ. Essa decisao evita a criacao de uma camada de services sem regra de negocio propria, mantendo o projeto mais direto, simples e performatico para o seu proposito.

---

## Modelagem Relacional

A entidade central do dominio e `Carga`, responsavel por representar uma carga transportada. A partir dela, o sistema relaciona rotas, tipos de carga, leituras de sensores, alertas e historico de ocorrencias.

### Entidades do Projeto

| Entidade | Descricao |
| --- | --- |
| `Carga` | Registra as cargas transportadas, seu status e seus vinculos logisticos. |
| `Alerta` | Armazena alertas relacionados a uma carga, como violacoes termicas ou eventos de risco. |
| `HistoricoAlerta` | Mantem o historico auditavel das ocorrencias e alertas registrados. |
| `SensorLeitura` | Guarda leituras de temperatura, umidade e data de coleta dos sensores. |
| `Rota` | Define origem, destino e distancia em quilometros. |
| `TipoCarga` | Define o tipo da carga e seus limites ideais de temperatura. |

### Relacionamentos

- Uma `Carga` pode possuir varios registros em `Alerta`.
- Uma `Carga` pode possuir varias leituras em `SensorLeitura`.
- Uma `Carga` pode possuir registros de acompanhamento em `HistoricoAlerta`.
- Uma `Carga` pertence a uma `Rota`.
- Uma `Carga` possui um `TipoCarga`.
- Uma `Rota` pode estar associada a varias cargas.
- Um `TipoCarga` pode estar associado a varias cargas.

### Estrutura Geral

```text
        Rota           TipoCarga
          |                |
          +-------+--------+
                  |
                Carga
                  |
      +-----------+--------------+
      |           |              |
   Alerta   SensorLeitura   HistoricoAlerta
```

---

## Endpoints da API

Com o projeto em execucao, a documentacao interativa pode ser acessada pelo Swagger:

```text
http://localhost:5165/swagger
```

### GET `/api/Relatorios/dashboard-resumo`

Retorna o panorama consolidado do dia, incluindo:

- quantidade de cargas ativas;
- numero de alertas registrados no dia;
- prejuizo total estimado.

### GET `/api/Relatorios/perdas-estimadas`

Agrupa incidentes criticos por tipo de produto e calcula o prejuizo estimado de acordo com as regras financeiras da OrbiFreight.

Regras utilizadas:

| Tipo de Produto | Perda Estimada |
| --- | ---: |
| Vacina | R$ 5.000,00 por quebra termica |
| Laticinios | R$ 1.500,00 por quebra termica |

### GET `/api/Relatorios/ranking-rotas`

Consolida as rotas logisticas com maior volume de sinistros, permitindo identificar trajetos com maior risco operacional.

### GET `/api/Relatorios/historico-alertas`

Retorna o historico auditavel de alertas cadastrados, com suporte a paginacao.

Exemplo de uso:

```http
GET /api/Relatorios/historico-alertas?pagina=1&tamanho=10
```

Dados retornados:

- nivel de risco;
- descricao do evento;
- data de criacao;
- carga relacionada.

---

## Como Executar o Projeto

### 1. Clonar o Repositorio

```bash
git clone https://github.com/Hayzer3/OrbiFreight.Analytics.git
cd OrbiFreight.Analytics
```

### 2. Configurar a Connection String

Abra o arquivo `appsettings.json` e configure a string de conexao com o Oracle utilizando as credenciais da FIAP:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=usuario;Password=SUA_SENHA;"
  }
}
```

### 3. Restaurar Dependencias

```bash
dotnet restore
```

### 4. Executar a Aplicacao

```bash
dotnet run
```

### 5. Acessar o Swagger

```text
http://localhost:5165/swagger
```

---

## Exemplos de Status e Regras de Negocio

A API trabalha com dados de cargas em transporte e eventos criticos. Alguns exemplos de estados e classificacoes utilizados no contexto da aplicacao:

- `EM_TRANSITO`: carga ativa em deslocamento;
- `CRITICO`: alerta com alto impacto operacional ou financeiro;
- `ALTO`: alerta relevante que exige acompanhamento;
- `NORMAL`: ocorrencia registrada sem impacto critico imediato.

---

## Videos de Entrega

- [**Video de demonstracao completa:** ](https://youtu.be/lgvnZS5-yeg)
- [**Video pitch da solucao:**](https://www.youtube.com/watch?v=OkM58frbgjE)

---

## Integrantes da Equipe

| RM | Nome Completo |
| --- | --- |
| 564434 | Eduarda Weiss Ventura |
| 565146 | Maria Gabriela Landim Severo |
| 559072 | Samara Porto Souza |
| 566503 | Lucas Nunes Soares |
| 566520 | Camily Vitoria Pereira Macie |

---

## Licenca

Projeto desenvolvido para fins academicos na FIAP, como parte da Global Solution 2026/1.
