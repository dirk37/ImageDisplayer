using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDisplayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DragDropHandler(object sender, DragEventArgs e)
        { //process files that are dragged onto the form

            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

            foreach (string file in files)
            {
                try //report any errors as invalid image

                {
                    Image fileimage = Image.FromFile(file);
                    addpicture(fileimage,e.X,e.Y); //add picture for each file at coordinates where it was dropped
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Image");
                }
                
            }

        }

  
        private void DragOverHandler(object sender, DragEventArgs e)
        {
            //enable dragging and dropping
            e.Effect = DragDropEffects.Copy;  
        }

        List<PictureBox> pictureboxes = new List<PictureBox>();
        private void addpicture(Image fileimage, int x, int y)
        { //create new picture box for each image and add to form

            PictureBox newpb = new PictureBox();
            newpb.Location = this.PointToClient(new Point(x, y));
            newpb.Image = fileimage;
            newpb.Height = 400;
            newpb.Width = (int)((double)newpb.Image.Width / (double)newpb.Image.Height * 400.0); //maintain image proportions
            newpb.BorderStyle = BorderStyle.FixedSingle;
            newpb.SizeMode = PictureBoxSizeMode.Zoom;
            newpb.MouseMove += PbMouseMove;
            newpb.MouseDown += PbMouseDown;
            newpb.MouseWheel += PbMouseWheel;
            newpb.MouseDoubleClick += PbDoubleClick;
            
            this.Controls.Add(newpb);

            newpb.BringToFront(); //put latest images on top
            pictureboxes.Add(newpb);
        }

        private void arrangeboxes()
        {
            int totalarea = this.Height * this.Width;
            int realestateperimage = totalarea / pictureboxes.Count;

            int i = 0;
            int x = 0;
            int y = 0;
            int ysum = 0;
            foreach (PictureBox pb  in pictureboxes)
            {
                //scale each picturebox to approximate max size
                double scalefactor = (double)realestateperimage / (double)(pb.Height * pb.Width);
                pb.Height = (int)((double)pb.Height * Math.Sqrt(scalefactor));
                pb.Width = (int)((double)pb.Width * Math.Sqrt(scalefactor));

                //set picture box to new location
                pb.Location = new Point(x, y);

                //add height to sum for average
                ysum += pb.Height;

                //check if picture goes more than 10% off edge of form
                if((x + pb.Width * 1.5) < ((double)this.Width))
                {
                    x = x + pb.Width;
                }
                //if it goes off form jump down to next row using average height for y
                else
                {
                    x = 0; //reset x offset
                    y = y + (int)((double)ysum / (double)(i + 1));
                    ysum = 0; //reset heigh average 
                }                     


                i++;
            }
        }

        private Point MouseDownLocation; //mousedown tracking for drag and drop
        private void PbMouseMove(object sender, MouseEventArgs e)
        {
            //for dragging pictures around the window
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                //calculate new location from mouse movement and existing location
                pb.Left = e.X + pb.Left - MouseDownLocation.X;
                pb.Top = e.Y + pb.Top - MouseDownLocation.Y;
            }


        }

        PictureBox selectedPb; //keep track of current picture box for context menu
        private void PbMouseDown(object sender, MouseEventArgs e)
        {// track left click location for dragging images around
 
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            //present context menu on right click for closing image
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                selectedPb = (PictureBox)sender;
                contextMenuStrip1.Show(selectedPb, e.X, e.Y);

            }
        }

        private void PbMouseWheel(object sender, MouseEventArgs e)
        {//scale image with scroll wheel

            int deltaconstant = SystemInformation.MouseWheelScrollDelta; //system multiplier per scroll wheel click
            PictureBox pb = (PictureBox)sender;
            //increase / decrease size by 8% per click
            int newheight = (int)(pb.Height * (1 + 0.08 * e.Delta / deltaconstant));
            int newwidth = (int)(pb.Width * (1 + 0.08 * e.Delta / deltaconstant));
            //verify image is not too small or too large
            if (newheight > 50 & newwidth > 50 & newheight < 8000 & newwidth < 8000)
            {
                pb.Height = newheight;
                pb.Width = newwidth;
            }
            
        }

        private void PbDoubleClick(object sender, MouseEventArgs e)
        {//Double click handler used to send images forwards and backwards
            PictureBox pb = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                pb.BringToFront();
            }
        }


        private void closeImageToolStripMenuItem_Click(object sender, EventArgs e)
        { //handle close button on the right click menu

            pictureboxes.Remove(selectedPb);
            selectedPb.Image.Dispose(); //destroy image handle to release file
            selectedPb.Dispose(); //destroy picturebox 
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        { //send selected picture box behind others

            selectedPb.SendToBack();
        }

        private void autoArrangeToolStripMenuItem_Click(object sender, EventArgs e)
        { //arrange images 
            arrangeboxes();
        }

    }
}
