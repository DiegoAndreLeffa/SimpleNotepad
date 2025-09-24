// SimpleNotepad.App/FileService.cs

using System.IO;

namespace SimpleNotepad.App
{
    // Esta classe tem a responsabilidade única de lidar com operações de arquivo.
    public class FileService
    {
        // Salva o conteúdo de texto em um arquivo no caminho especificado.
        // Usa StreamWriter para escrever no arquivo de forma eficiente.
        public void SaveFile(string filePath, string content)
        {
            // O bloco 'using' garante que o StreamWriter seja fechado e os recursos liberados,
            // mesmo que ocorram exceções.
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        // Abre e lê todo o conteúdo de um arquivo do caminho especificado.
        // Usa StreamReader para ler o conteúdo do arquivo.
        public string OpenFile(string filePath)
        {
            // Verifica se o arquivo realmente existe antes de tentar lê-lo.
            if (!File.Exists(filePath))
            {
                // Lança uma exceção mais específica para que a camada de UI possa tratar o erro.
                throw new FileNotFoundException("O arquivo não foi encontrado.", filePath);
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lê todo o conteúdo do arquivo do início ao fim.
                return reader.ReadToEnd();
            }
        }
    }
}