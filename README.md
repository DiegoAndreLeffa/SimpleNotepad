# SimpleNotepad - Bloco de Notas com Interface Gráfica em C#

Um projeto de Bloco de Notas para desktop com uma interface gráfica construída em C#. O objetivo principal deste projeto é aplicar e demonstrar boas práticas de desenvolvimento de software, incluindo a separação de responsabilidades (SOLID), testes unitários e organização de código.

## Funcionalidades

* **Interface Gráfica Intuitiva:** Uma janela simples com um menu para todas as operações.
* **Criar Novo Documento:** Limpa a área de texto para um novo arquivo.
* **Abrir Arquivo:** Abre uma caixa de diálogo para selecionar e carregar arquivos `.txt` existentes.
* **Salvar e Salvar Como:** Permite salvar o trabalho atual em um arquivo novo ou sobrescrever um existente.

## Princípios e Boas Práticas Aplicadas

Este projeto foi estruturado para ser um exemplo prático de engenharia de software de qualidade.

* **Arquitetura em Camadas:**
  * **`SimpleNotepad.App` (Camada de Lógica):** Contém a lógica de negócio principal (o `FileService`), que é responsável por ler e escrever em arquivos. Esta camada não sabe nada sobre a interface do usuário.
  * **`SimpleNotepad.UI` (Camada de Apresentação):** A interface gráfica com Windows Forms. Ela é responsável por exibir a informação e capturar as interações do usuário, delegando as operações de arquivo para a camada de lógica.
  * **`SimpleNotepad.Tests` (Camada de Testes):** Projeto dedicado a testar a camada de lógica, garantindo que o `FileService` funcione de forma correta e isolada.

* **Princípios SOLID:**
  * **SRP (Princípio da Responsabilidade Única):** A classe `FileService` tem a única responsabilidade de manipular arquivos. A classe `Form1` tem a única responsabilidade de gerenciar a interface do usuário. Essa separação torna o código mais fácil de manter e testar.

* **Testes Unitários:**
  * O projeto utiliza **xUnit** para validar o comportamento do `FileService`, garantindo que as operações de abrir e salvar arquivos sejam confiáveis.

* **Gerenciamento de Código Fonte com Git:**
  * Uso de uma estratégia de branches (`main`, `develop`, `feature/*`) para manter o histórico de desenvolvimento limpo e organizado.
  * Commits semânticos para descrever claramente o propósito de cada alteração no código.

## Tecnologias Utilizadas

* **.NET e C#**
* **Windows Forms (WinForms):** Para a construção da interface gráfica do usuário.
* **xUnit:** Framework de testes unitários.
* **StreamWriter / StreamReader:** Para manipulação eficiente de I/O de arquivos.

## Como Executar a Aplicação

Para rodar o projeto, você precisará ter o **.NET SDK** instalado.

1. **Clone o repositório:**

2. **Navegue até a pasta raiz do projeto:**

    ```bash
    cd SimpleNotepad
    ```

3. **Execute a aplicação com interface gráfica:**
    O comando `dotnet run` precisa ser direcionado ao projeto de UI.

    ```bash
    dotnet run --project SimpleNotepad.UI
    ```

## Como Executar os Testes

Os testes validam a lógica de manipulação de arquivos.

1. **Navegue até a pasta raiz do projeto:**

    ```bash
    cd SimpleNotepad
    ```

2. **Execute o comando de teste:**

    ```bash
    dotnet test
    ```
