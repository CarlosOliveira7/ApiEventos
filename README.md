# API de Eventos

Bem-vindo à API de Eventos! Esta aplicação simples permite que você gerencie eventos, fornecendo endpoints para criar, recuperar, atualizar e excluir eventos.

## Como Iniciar

### Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Instalação

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/CarlosOliveira7/ApiEventos.git
    cd ApiEventos
    ```

2. **Instale as dependências:**

    ```bash
    dotnet restore
    ```

3. **Execute a aplicação:**

    ```bash
    dotnet run
    ```

    A API estará disponível em http://localhost:5069 por padrão.

## Endpoints

### GET /api/Events

Retorna todos os eventos disponíveis.

### GET /api/Events/{id}

Retorna um evento específico com base no ID.

### POST /api/Events

Cria um novo evento.

### PUT /api/Events/{id}

Atualiza um evento existente com base no ID.

### DELETE /api/Events/{id}

Exclui um evento existente com base no ID.

## Exemplo de Uso (usando cURL)

### Criar um Novo Evento:

```bash
curl -X POST -H "Content-Type: application/json" -d '{"title":"Novo Evento","description":"Descrição do Evento","startDate":"2023-01-01T12:00:00","endDate":"2023-01-01T15:00:00"}' http://localhost:5069/api/Events
