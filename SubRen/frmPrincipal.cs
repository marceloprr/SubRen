using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRen
{

    public partial class frmPrincipal : Form
    {
        private String CaminhoVideos { get; set; }
        private String CaminhoLegendas { get; set; }

        private string[] extensoesVideos = new string[] { ".avi", ".mp4", ".mkv" };
        private string[] extensoesLegendas = new string[2] { ".srt", ".sub" };
        private string[] chavesSeason = new string[4] { "SSSEEE", "SEE", "SxEE", "SSxEE" };

        private readonly string ARQUIVO_WILD_CARD = "*";

        public frmPrincipal()
        {
            InitializeComponent();
#if (DEBUG)
            SetCaminhoVideos(@"D:\MarceloP\Videos\");
            chkMesmoVideo.Checked = false;
            SetCaminhoLegendas(@"D:\MarceloP\Legendas");
#endif
            ProcessaCheckMesmoVideo();
        }

        private void btnSelecionarVideo_Click(object sender, EventArgs e)
        {
            fbdSelecionarDiretorios.SelectedPath = txtVideo.Text;
            if (fbdSelecionarDiretorios.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetCaminhoVideos(fbdSelecionarDiretorios.SelectedPath);
            }
        }

        private void SetCaminhoVideos(string caminho)
        {
            CaminhoVideos = caminho;
            txtVideo.Text = caminho;
            if (chkMesmoVideo.Checked)
            {
                SetCaminhoLegendas(CaminhoVideos);
            }
        }

        private void SetCaminhoLegendas(string caminho)
        {
            CaminhoLegendas = caminho;
            txtLegendas.Text = caminho;
        }

        private void chkMesmoVideo_CheckedChanged(object sender, EventArgs e)
        {
            ProcessaCheckMesmoVideo();
        }

        private void ProcessaCheckMesmoVideo()
        {
            if (chkMesmoVideo.Checked)
            {
                txtLegendas.Enabled = false;
                SetCaminhoLegendas(txtVideo.Text);
            }
            else
            {
                txtLegendas.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaminhoVideos = txtVideo.Text;
            CaminhoLegendas = txtLegendas.Text;
            if (validaParametros())
            {
                ProcessaArquivos();
            }
        }

        private bool validaParametros()
        {
            return consisteCaminho(CaminhoVideos) && consisteCaminho(CaminhoLegendas);
        }

        private bool consisteCaminho(string caminho)
        {
            if (String.IsNullOrWhiteSpace(caminho) || !Directory.Exists(caminho))
            {
                MessageBox.Show("O(s) diretório(s) selecionado(s) deve(m) ser válido(s).\nFavor verificar o preenchimento", "Erro no diretório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ProcessaArquivos()
        {
            txtResultado.Clear();
            ProcessaDiretorio(CaminhoVideos);
        }

        private void ProcessaDiretorio(string caminho)
        {
            var listaVideos = new List<string>();
            foreach (var extensao in extensoesVideos)
            {
                listaVideos.AddRange(Directory.GetFiles(caminho, insereWildCard(extensao)).ToList());
            }
            txtResultado.AppendText(String.Concat("Processando Diretório: ", caminho, System.Environment.NewLine));
            foreach (var arquivoCompleto in listaVideos)
            {
                var arquivo = new FileInfo(arquivoCompleto);
                txtResultado.AppendText(String.Format("\t {0} ... ", arquivo.Name));
                if (ProcuraLegendas(arquivo.Name, caminho))
                {
                    txtResultado.AppendText("Processado OK!");
                }
                else
                {
                    txtResultado.AppendText("Legenda não encontrada!");
                }
                txtResultado.AppendText(System.Environment.NewLine);
            }
        }

        private string insereWildCard(string extensao)
        {
            return String.Concat(ARQUIVO_WILD_CARD, extensao);
        }

        private bool ProcuraLegendas(string nomeArquivoVideo, string caminhoDestino)
        {
            foreach (var extensao in extensoesLegendas)
            {
                if (TestaArquivoEMove(caminhoDestino, Path.ChangeExtension(nomeArquivoVideo, extensao)))
                {
                    return true;
                }
                else if (TestaArquivoEMove(caminhoDestino, GeraPossibilidadeDeArquivos(nomeArquivoVideo, extensao), nomeArquivoVideo))
                {
                    return true;
                }
            }
            return false;
        }

        private string GeraPossibilidadeDeArquivos(string nomeArquivoVideo, string extensao)
        {
            //var ret = new List<string>();
            var ret = String.Empty;
            var reg = String.Empty;
            var mascara = "S0{0}E{1}{2}";
            var idxSeason = 0;
            var idxEpisodio = 0;
            foreach (var chaveSeason in chavesSeason)
            {
                switch (chaveSeason)
                {
                    case "SSSEEE":
                        {
                            reg = @"S\d{2}E\d{2}";
                            idxSeason = 2;
                            idxEpisodio = 4;
                        } break;
                    case "SEE":
                        {
                            reg = @" \d{3} ";
                            idxSeason = 1;
                            idxEpisodio = 2;
                        } break;
                    case "SxEE":
                        {
                            reg = @" - \d{1}[x]\d{2}";
                            idxSeason = 3;
                            idxEpisodio = 5;
                        } break;
                    case "SSxEE":
                        {
                            reg = @" - \d{2}[x]\d{2}";
                            idxSeason = 4;
                            idxEpisodio = 6;
                        } break;
                }

                Regex rx = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var seasonEEpisodio = rx.Match(nomeArquivoVideo).Value;
                if (!String.IsNullOrWhiteSpace(seasonEEpisodio))
                {
                    var posSeason = nomeArquivoVideo.IndexOf(seasonEEpisodio);
                    var nomeSerie = nomeArquivoVideo.Substring(0, posSeason);
                    nomeSerie = nomeSerie.Replace(" ", ARQUIVO_WILD_CARD);
                    seasonEEpisodio = String.Format(mascara, seasonEEpisodio[idxSeason], seasonEEpisodio[idxEpisodio++], seasonEEpisodio[idxEpisodio]);
                    var arquivoLegenda = String.Concat(nomeSerie, ARQUIVO_WILD_CARD, seasonEEpisodio, ARQUIVO_WILD_CARD, extensao);
                    var listArquivos = Directory.GetFiles(CaminhoLegendas, arquivoLegenda);
                    if (listArquivos.Count() == 1)
                    {
                        ret = listArquivos.First();
                        break;
                    }
                }
            }
            return ret;
        }

        private bool TestaArquivoEMove(string caminhoDestino, string arquivoLegenda)
        {
            return TestaArquivoEMove(caminhoDestino, arquivoLegenda, Path.GetFileName(arquivoLegenda));
        }

        private bool TestaArquivoEMove(string caminhoDestino, string arquivoLegenda, string nomeArquivoVideo)
        {
            var arquivoASerCopiado = Path.Combine(CaminhoLegendas, arquivoLegenda);
            if (File.Exists(arquivoASerCopiado))
            {
                var arquivoDestino = Path.Combine(caminhoDestino, Path.ChangeExtension(nomeArquivoVideo, Path.GetExtension(arquivoLegenda)));
                if (!arquivoASerCopiado.Equals(arquivoDestino))
                {
                    if (File.Exists(arquivoDestino))
                    {
                        File.Delete(arquivoDestino);
                    }
                    File.Move(arquivoASerCopiado, arquivoDestino);
                }
                return true;
            }
            return false;
        }

        private void txtVideo_TextChanged(object sender, EventArgs e)
        {
            if (chkMesmoVideo.Checked)
            {
                txtLegendas.Text = txtVideo.Text;
            }
        }
    }
}
