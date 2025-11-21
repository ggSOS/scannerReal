using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace scannerReal
{
    internal class MensagemBot : Mensagem
    {
        public MensagemBot(string texto, string caminhoImagem) : base(
            texto,
            caminhoImagem,
            HorizontalAlignment.Left,
            new Thickness(10, 5, 50, 5),
            new SolidColorBrush(Color.FromRgb(42, 50, 54)))
        {
        }
    }
}
