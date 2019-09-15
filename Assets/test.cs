//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Speech.Synthesis;
//using System.Speech.Recognition;
//using System.Threading;

//namespace Speaker2
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//        SpeechSynthesizer sSynth = new SpeechSynthesizer();
//        PromptBuilder pBuilder = new PromptBuilder();
//        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();



//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            pBuilder.ClearContent();
//            pBuilder.AppendText(textBox1.Text);
//            sSynth.Speak(pBuilder);
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            button2.Enabled = false;
//            button3.Enabled = true;
//            Choices sList = new Choices();
//            sList.Add(new string[]
//            { "hello", "What is my name?", "test", "it works", "exit", "Where is Howon?", "What is my mother's name?",
//                "What do you think about Daeyeon?", "Who is the most handsome professor in my university?", "What is the most effective way to learn English?",
//            "Thank you", "See you later", "Hi.Nice to meet you"
//            });
//            Grammar gr = new Grammar(new GrammarBuilder(sList));
//            try
//            {
//                sRecognize.RequestRecognizerUpdate();
//                sRecognize.LoadGrammar(gr);
//                sRecognize.SpeechRecognized += SRecognize_SpeechRecognized;
//                sRecognize.SetInputToDefaultAudioDevice();
//                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
//            }
//            catch
//            {
//                return;
//            }
//        }

//        private void SRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
//        {
//            //throw new NotImplementedException();
//            //MessageBox.Show("Speech Recognized : " + e.Result.Text.ToString());

//            if (e.Result.Text == "exit")
//            {
//                Application.Exit();
//            }
//            else if (e.Result.Text == "Hi.Nice to meet you")
//            {
//                textBox1.Text = "Hi Nice to meet you too";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "Where is Howon?")
//            {
//                textBox1.Text = "Howon is in China. He is missing us.";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "What is my name?")
//            {
//                textBox1.Text = "Your name is Jinwon Kim";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "What is my mother's name?")
//            {
//                textBox1.Text = "Your mother's name is Kang Mungsook ";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "What do you think about Daeyeon?")
//            {
//                textBox1.Text = "He is a stupid. And He can be called like byung-sin";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "Who is the most handsome professor in my university?")
//            {
//                textBox1.Text = "I think professor Aziz is the most handsome man.";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "What is the most effective way to learn English?")
//            {
//                textBox1.Text = "I recommand you to use 'Chat buddy' which is VR application";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "Thank you")
//            {
//                textBox1.Text = "You're welcome";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else if (e.Result.Text == "See you later")
//            {
//                textBox1.Text = "Bye~Bye~";
//                pBuilder.ClearContent();
//                pBuilder.AppendText(textBox1.Text);
//                sSynth.Speak(pBuilder);
//            }
//            else
//            {
//                textBox1.Text = textBox1.Text = e.Result.Text.ToString();
//            }
//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            sRecognize.RecognizeAsyncStop();
//            button2.Enabled = true;
//            button3.Enabled = false;
//        }
//    }
//}
