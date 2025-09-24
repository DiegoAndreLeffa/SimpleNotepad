// SimpleNotepad.UI/Form1.cs

using System;
using System.IO;
using System.Windows.Forms;
using SimpleNotepad.App; // Importa nossa lógica de negócio!

namespace SimpleNotepad.UI
{
    public partial class Form1 : Form
    {
        // Instância do nosso serviço de arquivos. A UI não sabe como ele funciona, apenas o usa.
        private readonly FileService _fileService;
        
        // Armazena o caminho do arquivo atualmente aberto.
        private string _currentFilePath = null;

        // Componentes da UI (vamos instanciar aqui para ter acesso em toda a classe)
        private MenuStrip menuStrip;
        private TextBox mainTextBox;

        public Form1()
        {
            // Inicializa a nossa lógica de negócio
            _fileService = new FileService();

            // Método que o template do WinForms usa para inicializar componentes.
            InitializeComponent(); 
            InitializeCustomComponents(); // Nosso método para configurar a UI
        }

        private void InitializeCustomComponents()
        {
            // Configurações da Janela Principal
            this.Text = "Bloco de Notas Simples";
            this.Size = new System.Drawing.Size(800, 600);

            // 1. Criar o Menu Superior (MenuStrip)
            menuStrip = new MenuStrip();

            var arquivoMenuItem = new ToolStripMenuItem("Arquivo");
            var novoMenuItem = new ToolStripMenuItem("Novo", null, NovoMenuItem_Click);
            var abrirMenuItem = new ToolStripMenuItem("Abrir", null, AbrirMenuItem_Click);
            var salvarMenuItem = new ToolStripMenuItem("Salvar", null, SalvarMenuItem_Click);
            var salvarComoMenuItem = new ToolStripMenuItem("Salvar Como...", null, SalvarComoMenuItem_Click);
            
            arquivoMenuItem.DropDownItems.Add(novoMenuItem);
            arquivoMenuItem.DropDownItems.Add(abrirMenuItem);
            arquivoMenuItem.DropDownItems.Add(salvarMenuItem);
            arquivoMenuItem.DropDownItems.Add(salvarComoMenuItem);
            menuStrip.Items.Add(arquivoMenuItem);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // 2. Criar a Caixa de Texto Principal (TextBox)
            mainTextBox = new TextBox();
            mainTextBox.Multiline = true;
            mainTextBox.Dock = DockStyle.Fill; // Faz a caixa de texto ocupar todo o espaço restante
            mainTextBox.ScrollBars = ScrollBars.Vertical; // Adiciona barra de rolagem

            this.Controls.Add(mainTextBox);
            mainTextBox.BringToFront(); // Garante que a caixa de texto fique na frente do menu
        }

        // --- Event Handlers para os cliques no Menu ---

        private void NovoMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Clear();
            _currentFilePath = null;
            this.Text = "Novo Documento - Bloco de Notas Simples";
        }

        private void AbrirMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = _fileService.OpenFile(openFileDialog.FileName);
                        mainTextBox.Text = content;
                        _currentFilePath = openFileDialog.FileName;
                        this.Text = Path.GetFileName(_currentFilePath) + " - Bloco de Notas Simples";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao abrir o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SalvarMenuItem_Click(object sender, EventArgs e)
        {
            // Se o arquivo ainda não foi salvo (não tem caminho), age como "Salvar Como"
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                SalvarComoMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    _fileService.SaveFile(_currentFilePath, mainTextBox.Text);
                    this.Text = Path.GetFileName(_currentFilePath) + " - Bloco de Notas Simples";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SalvarComoMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _fileService.SaveFile(saveFileDialog.FileName, mainTextBox.Text);
                        _currentFilePath = saveFileDialog.FileName;
                        this.Text = Path.GetFileName(_currentFilePath) + " - Bloco de Notas Simples";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}