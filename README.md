# OrbiFreight Analytics API - Global Solution 2026/1

**Disciplina:** Advanced Business Development with .NET  
**Instituição:** FIAP - 2TDS

## Sobre o Projeto

O **OrbiFreight** é uma plataforma de monitoramento inteligente de transporte de cargas alimentícias e perecíveis. Esta API, denominada **OrbiFreight Analytics**, é o componente estratégico (Backoffice) do ecossistema.

Desenvolvida em **ASP.NET Core 8** e utilizando **Entity Framework Core** com abordagem *Database First* (Fluent API), a aplicação atua de forma analítica sobre um banco de dados **Oracle 19c**.

Ela consome as informações de telemetria e alertas gerados pela operação para fornecer:
- Consolidação de dados em um Dashboard de alto desempenho.
- Histórico paginado de alertas críticos.
- Estimativa financeira de perdas baseada no tipo de carga e incidentes térmicos.
- Ranking analítico das rotas mais problemáticas.

---

## Arquitetura Macro

> Atenção: substitua o link abaixo pela URL da imagem do diagrama exportado do ArchiMate ou Draw.io.

![Arquitetura da Solução](https://link-da-sua-imagem-aqui.com/diagrama.png)

---

## Instruções de Acesso e Execução

### 1. Clonar o Repositório

```bash
git clone https://github.com/SeuUsuario/OrbiFreight.Analytics.git
cd OrbiFreight.Analytics
```

### 2. Configurar o Banco de Dados Oracle

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=SEU_RM;Password=SUA_SENHA;"
  }
}
```

### 3. Restaurar Dependências

```bash
dotnet restore
```

### 4. Executar a Aplicação

```bash
dotnet run
```

## Vídeos de Entrega

### Vídeo Demonstração
[INSERIR_LINK_AQUI]

### Vídeo Pitch da Solução
[INSERIR_LINK_AQUI]

## Integrantes da Equipe

| RM | Nome Completo |
|----|---------------|
| 564434 | Eduarda Weiss Ventura |
| 565146 | Maria Gabriela Landim Severo |
| 559072 | Samara Porto Souza |
| 566503 | Lucas Nunes Soares |
| 566520 | Camily Vitoria Pereira Maciel |
