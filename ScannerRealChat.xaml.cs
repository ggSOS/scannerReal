using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace scannerReal
{
    /// <summary>
    /// Lógica interna para ScannerRealChat.xaml
    /// </summary>
    public partial class ScannerRealChat : Window
    {
        private ObservableCollection<Mensagem> mensagens = new ObservableCollection<Mensagem>();

        public ScannerRealChat()
        {
            InitializeComponent();
            chatItemsControl.ItemsSource = mensagens;
        }

        private async void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            // Mensagem do usuário (direita)
            await System.Threading.Tasks.Task.Delay(100);
            mensagens.Add(new MensagemUsuario("Poderia calcular quanto dinheiro tem aqui?", "images/1.jpg"));
            scrollViewer.ScrollToEnd();

            // Resposta do sistema (esquerda)
            await System.Threading.Tasks.Task.Delay(400);
            mensagens.Add(new MensagemBot("Claro! Deu um Total de R$25,65", "images/1Analisado.png"));
            scrollViewer.ScrollToEnd();
        }
    }
}