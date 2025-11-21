using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace scannerReal
{
    class Mensagem
    {
        public string Texto { get; set; }
        public string CaminhoImagem { get; set; }
        public HorizontalAlignment Alinhamento { get; set; }
        public Thickness Margin { get; set; }
        public Brush Background { get; set; }

        public Mensagem(string texto, string caminhoImagem, HorizontalAlignment alinhamento, Thickness margin, Brush background)
        {
            Texto = texto;
            CaminhoImagem = caminhoImagem;
            Alinhamento = alinhamento;
            Margin = margin;
            Background = background;
        }
    }
}
