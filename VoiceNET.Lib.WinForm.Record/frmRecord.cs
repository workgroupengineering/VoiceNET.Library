﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib.RecordDemo
{
    public partial class frmRecordDemo : Form
    {
        public frmRecordDemo() => InitializeComponent();

        private void btnRecord_Click(object sender, EventArgs e)
        {

            VBuilder.StartRecord();

            btnStop.Enabled = true;

            btnRecord.Enabled = false;

        }

        private void frmRecordDemo_Load(object sender, EventArgs e)
        {

            // Path in actual use - VBuilder.ModelPath(Path.GetFullPath("MLModel.zip"));

            VBuilder.ModelPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\SampleModel\MLModel.zip");

            Enabled = false;

            lbResult.Text = "Loading Model...";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (VBuilder.loadModel())
            {
                Enabled = true;

                lbResult.Text = "...";

                timer1.Stop();

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            VBuilder.StopRecord();

            lbResult.Text = VBuilder.Result(true);

            btnRecord.Enabled = true;

            btnStop.Enabled = false;

        }
    }
}
