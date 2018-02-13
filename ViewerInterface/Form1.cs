using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System.Threading;

namespace ViewerInterface
{
    public partial class MainWindow : Form
    {
        SftpClient compusaServer;
        GlobalDataBase envMonitor;
        BackgroundWorker fisherMan;
        public MainWindow()
        {
            InitializeComponent();

        }
        
        public void hireFisherMan()
        {
            if(fisherMan == null)
            {
                fisherMan = new BackgroundWorker();
                fisherMan.WorkerReportsProgress = true;
                fisherMan.DoWork += fisherMan_DoWork;
                fisherMan.RunWorkerCompleted += fisherMan_RunWorkerCompleted;
                fisherMan.RunWorkerAsync();
            }
        } 
        private void fisherMan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            monitorSharedMemory();
            
            Thread.Sleep(500);
        }
        private void fisherMan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (envMonitor.NewContent)
            {
                updateGUI();
                envMonitor.NewContent = false;
            }
            this.TopMost = true;
            worker.RunWorkerAsync();
        }
        
        private void MainWindow_Load(object sender, EventArgs e)
        {
           
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Location = new Point(x, y);
            
            envMonitor = new GlobalDataBase();
            var connectionInfo = new ConnectionInfo("fireplug.dreamhost.com",
                                                     "compusa",
                                                     new PasswordAuthenticationMethod("compusa", "blackmagic1"));
            compusaServer = new SftpClient(connectionInfo);
            compusaServer.Connect();
            if (compusaServer.IsConnected) {
                envMonitor.ConnectionStatus = "compusa.live : connected";
                
                hireFisherMan();
                
        }
        }
        public void monitorSharedMemory()
        {
            string localDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) ;
            string remoteDirectory = @"/home/compusa/compusa.live/php/sharedMemory";
            
            
            List<SftpFile> availableFiles = compusaServer.ListDirectory(remoteDirectory).ToList();
            foreach(var tempFile in availableFiles) {
                string tempName = tempFile.Name;
               
                if ((tempName.EndsWith(".client"))){

                    using(Stream fileStream = File.Create(localDirectory+"/"+tempName))
                    {
                        compusaServer.DownloadFile(remoteDirectory+"/"+tempName, fileStream);
                    }
                    string[] contents = File.ReadAllLines(localDirectory + "/" + tempName);
                    foreach(string i in contents)
                    {
                        envMonitor.Log = i;
                    }
                    File.Delete(localDirectory + "/" + tempName);
                    compusaServer.DeleteFile(remoteDirectory + "/" + tempName);
                    //envMonitor.Log = tempName;
                    envMonitor.NewContent = true;
                }
                
                
            }
            
            
        }
        private void updateGUI()
        {
            if(envMonitor != null)
            {
                txt_logger.Clear();
                foreach(string message in envMonitor.Logger)
                {
                    txt_logger.AppendText(message + "\n");
                    
                }              
            }
        }
        class GlobalDataBase
        {
            private bool newContent;
            private string connectionStatus;
            private List<string> logger = new List<string>();
            private string log;
            public string Log
            {
                get { return log; }
                set {
                    log = value;
                    Logger.Add(value);
                }
            }

            public List<string> Logger {
                get { return logger; }
                set { logger = value;  }
                }
            public string ConnectionStatus { get; set; }

            public bool NewContent
            {
                get
                {
                    return newContent;
                }

                set
                {
                    newContent = value;
                }
            }

            public GlobalDataBase()
            {
                connectionStatus = "compusa.live : disconnected";
                logger = new List<string>();
                
            }
            
        }
        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 0x84:
        //            base.WndProc(ref m);
        //            if ((int)m.Result == 0x1)
        //                m.Result = (IntPtr)0x2;
        //            return;
        //    }

        //    base.WndProc(ref m);
        //}
        //private void x_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        
    }
}
