// SimpleNotepad.Tests/FileServiceTests.cs

using Xunit;
using SimpleNotepad.App;
using System.IO;
using System;

namespace SimpleNotepad.Tests
{
    public class FileServiceTests
    {
        private readonly FileService _fileService;
        private readonly string _testFilePath;

        // O construtor é executado antes de cada teste, configurando um ambiente limpo.
        public FileServiceTests()
        {
            _fileService = new FileService();
            // Cria um nome de arquivo de teste único para evitar conflitos.
            _testFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.txt");
        }

        [Fact]
        public void SaveFile_ShouldCreateFileWithCorrectContent()
        {
            // Arrange (Organização)
            string content = "Este é um teste.";

            // Act (Ação)
            _fileService.SaveFile(_testFilePath, content);

            // Assert (Verificação)
            Assert.True(File.Exists(_testFilePath));
            string readContent = File.ReadAllText(_testFilePath);
            Assert.Equal(content, readContent);

            // Cleanup (Limpeza)
            File.Delete(_testFilePath);
        }

        [Fact]
        public void OpenFile_ShouldReturnCorrectContent()
        {
            // Arrange
            string content = "Olá, Mundo!";
            File.WriteAllText(_testFilePath, content);

            // Act
            string readContent = _fileService.OpenFile(_testFilePath);

            // Assert
            Assert.Equal(content, readContent);

            // Cleanup
            File.Delete(_testFilePath);
        }

        [Fact]
        public void OpenFile_WhenFileDoesNotExist_ShouldThrowFileNotFoundException()
        {
            // Arrange
            string nonExistentFilePath = "caminho/para/arquivo/inexistente.txt";

            // Act & Assert
            // Verifica se o método lança a exceção esperada ao tentar abrir um arquivo que não existe.
            Assert.Throws<FileNotFoundException>(() => _fileService.OpenFile(nonExistentFilePath));
        }
    }
}