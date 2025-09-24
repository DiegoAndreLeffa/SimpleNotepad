// SimpleNotepad.App/Program.cs

using System;

namespace SimpleNotepad.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();

            Console.WriteLine("Bem-vindo ao Bloco de Notas Simples!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Digite 'abrir' para abrir um arquivo ou 'novo' para começar a editar.");

            string command = Console.ReadLine().ToLower();
            string content = "";
            string filePath = "";

            if (command == "abrir")
            {
                Console.WriteLine("Digite o caminho completo do arquivo:");
                filePath = Console.ReadLine();
                try
                {
                    content = fileService.OpenFile(filePath);
                    Console.WriteLine("Arquivo carregado. Conteúdo atual:");
                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao abrir o arquivo: {ex.Message}");
                    return; // Encerra a aplicação se não conseguir abrir
                }
            }

            Console.WriteLine("Digite seu texto. Para salvar e sair, digite ':wq' em uma nova linha.");
            
            string line;
            while ((line = Console.ReadLine()) != ":wq")
            {
                content += line + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                 Console.WriteLine("Digite o caminho completo para salvar o novo arquivo:");
                 filePath = Console.ReadLine();
            }
            
            try
            {
                fileService.SaveFile(filePath, content);
                Console.WriteLine($"Arquivo salvo com sucesso em: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}");
            }
        }
    }
}