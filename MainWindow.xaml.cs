using System.Windows;

namespace scannerReal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
            descricaoGeralText.Text =
                "Sua solução para a Identificação, Classificação e Contagem Manual de Cédulas e" +
                " Moedas, auxiliando o atendente com um sistema automatizado baseado em visão" +
                " computacional e machine learning.";
            tituloTopico1Text.Text = "Eficiência";
            descricaoTopico1Text.Text =
                "- Reduz o tempo de contagem do dinheiro." +
                "\n- Atendimentos mais fluídos em horários de maior movimento.";
            tituloTopico2Text.Text = "Redução de erros";
            descricaoTopico2Text.Text =
                "- Menos trocos incorretos." +
                "\n- Menos divergências de caixa no final do expediente.";
            tituloTopico3Text.Text = "Melhoria da experiência do atendente";
            descricaoTopico3Text.Text =
                "- Diminuição do cansaço gerado pela repetição da contagem manual." +
                "\n- Redução do estresse e carga mental.";
            tituloTopico4Text.Text = "Impacto no negócio";
            descricaoTopico4Text.Text =
                "- Atendimento mais rápido → filas menores." +
                "\n- Maior precisão → menos perdas financeiras." +
                "\n- Qualidade de serviço mais alta → satisfação do cliente.";
        }

        async void InitializeAsync()
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);

                // Quando o vídeo carregar, ativar tela cheia
                webView.CoreWebView2.NavigationCompleted += async (sender, e) =>
                {
                    if (e.IsSuccess)
                    {
                        // Aguarda um pouco para o player carregar
                        await System.Threading.Tasks.Task.Delay(700);

                        // Clica no botão de tela cheia automaticamente
                        await webView.CoreWebView2.ExecuteScriptAsync(@"
                            setTimeout(function() {
                                var video = document.querySelector('video');
                                var button = document.querySelector('.ytp-fullscreen-button');
                                var settingsButton = document.querySelector('.ytp-settings-button');
                                
                                if (video) {
                                    video.pause();

                                    // Tentar definir qualidade máxima através da API do player
                                    if (window.ytplayer && window.ytplayer.config) {
                                        var player = document.querySelector('#movie_player');
                                        if (player && player.setPlaybackQualityRange) {
                                            player.setPlaybackQualityRange('highres');
                                            player.setPlaybackQuality('highres');
                                        }
                                    }

                                    // deixar fullscreen
                                    if (button) {
                                        button.click();
                                    } else {
                                        video.requestFullscreen();
                                    }

                                    video.play();
                                }
                            }, 700);
                        ");
                    }
                };

                // Bloquear navegação fora do YouTube
                webView.CoreWebView2.NavigationStarting += (sender, e) =>
                {
                    if (!e.Uri.Contains("youtube.com"))
                    {
                        e.Cancel = true;
                    }
                };

                // Carregar vídeo normal
                webView.Source = new Uri("https://www.youtube.com/watch?v=nmbDHgqZ0Hw");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private async void testarButton_Click(object sender, RoutedEventArgs e)
        {
            await webView.CoreWebView2.ExecuteScriptAsync(@"
                var video = document.querySelector('video');
                if (video) {
                    video.pause();
                }
            ");

            ScannerRealChat scannerRealChat = new ScannerRealChat();
            scannerRealChat.Show();
        }
    }
}