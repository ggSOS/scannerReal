using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace scannerReal
{
    internal class MensagemUsuario: Mensagem
    {
        public MensagemUsuario(string texto, string caminhoImagem) : base(
            texto,
            caminhoImagem,
            HorizontalAlignment.Right,
            new Thickness(50, 5, 10, 5),
            new SolidColorBrush(Color.FromRgb(74, 158, 255)))
        {
        }
    }
}
