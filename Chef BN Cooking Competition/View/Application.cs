using System.Windows.Forms;
using System.Drawing;

namespace View
{
    class Application
    {
        static void Main(string[] args)
        {
            Form form = new Form()
            {
                MinimumSize = new Size(640, 480),
                MaximumSize = new Size(1920, 1080),
                Size = new Size(640, 480),
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location)
            };

            //form.WindowState = FormWindowState.Maximized;

            GroupBox optionsGroup = new GroupBox();

            optionsGroup.Size = new Size(form.Width * 4 / 5, form.Height * 4 / 5);
            optionsGroup.Location = new Point(form.Width / 2 - optionsGroup.Width / 2, form.Height / 2 - optionsGroup.Height / 2);

            Label optionsText = new Label();
            optionsText.Text = "Options";
            optionsText.TextAlign = ContentAlignment.MiddleCenter;
            optionsText.Location = new Point(optionsGroup.Width / 2 - optionsText.Width / 2, optionsText.Location.Y + optionsText.Height / 2);
            optionsGroup.Controls.Add(optionsText);

            Button res640x480 = new Button();
            Button res1024x576 = new Button();
            Button res1280x960 = new Button();
            Button res1600x900 = new Button();

            res640x480.Text = "640x480";
            res1024x576.Text = "1024x576";
            res1280x960.Text = "1280x960";
            res1600x900.Text = "1600x900";

            res640x480.Enabled = false;//Default size

            UpdateOptionMenu(form, optionsGroup, optionsText, res640x480, res1024x576, res1280x960, res1600x900);

            res640x480.Click += (o, s) =>
            {
                res640x480.Enabled = false;
                res1024x576.Enabled = true;
                res1280x960.Enabled = true;
                res1600x900.Enabled = true;
                
                form.Size = new Size(640, 480);

                UpdateOptionMenu(form, optionsGroup, optionsText, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1024x576.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = false;
                res1280x960.Enabled = true;
                res1600x900.Enabled = true;

                form.Size = new Size(1024, 576);

                UpdateOptionMenu(form, optionsGroup, optionsText, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1280x960.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = true;
                res1280x960.Enabled = false;
                res1600x900.Enabled = true;

                form.Size = new Size(1280, 960);

                UpdateOptionMenu(form, optionsGroup, optionsText, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1600x900.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = true;
                res1280x960.Enabled = true;
                res1600x900.Enabled = false;

                form.Size = new Size(1600, 900);

                UpdateOptionMenu(form, optionsGroup, optionsText, res640x480, res1024x576, res1280x960, res1600x900);
            };

            optionsGroup.Controls.Add(res640x480);
            optionsGroup.Controls.Add(res1024x576);
            optionsGroup.Controls.Add(res1280x960);
            optionsGroup.Controls.Add(res1600x900);

            form.Controls.Add(optionsGroup);

            Button testButton = new Button()
            {
                Text = "Test",
                Location = new Point(10, 50)
            };
            testButton.Click += (o, s) =>
            {

                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.WindowState = FormWindowState.Normal;
                optionsGroup.Size = new Size(form.Width * 4 / 5, (form.Height - SystemInformation.CaptionHeight) * 4 / 5);
                optionsGroup.Location = new Point(form.Width / 2 - optionsGroup.Width / 2, (form.Height / 2 - SystemInformation.CaptionHeight) - optionsGroup.Height / 2);
            };
            form.Controls.Add(testButton);

            Button exitButton = new Button()
            {
                Text = "Exit",
                Location = new Point(10, 10)
            };
            exitButton.Click += (o, s) =>
            {
                System.Windows.Forms.Application.Exit();
            };

            form.Controls.Add(exitButton);
            form.ShowDialog();

            while (form.Created)
            {

            }
        }

        private static void UpdateOptionMenu(Form form, GroupBox optionsGroup, Label optionsText, params Button[] buttons)
        {
            form.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - form.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - form.Height) / 2);

            if (form.FormBorderStyle == FormBorderStyle.None)
            {
                optionsGroup.Size = new Size(form.Width * 4 / 5, form.Height * 4 / 5);
                optionsGroup.Location = new Point(form.Width / 2 - optionsGroup.Width / 2, form.Height / 2 - optionsGroup.Height / 2);
            }
            else
            {
                optionsGroup.Size = new Size(form.Width * 4 / 5, (form.Height - SystemInformation.CaptionHeight) * 4 / 5);
                optionsGroup.Location = new Point(form.Width / 2 - optionsGroup.Width / 2, (form.Height / 2 - SystemInformation.CaptionHeight) - optionsGroup.Height / 2);
            }

            optionsText.TextAlign = ContentAlignment.MiddleCenter;
            optionsText.Location = new Point(optionsGroup.Width / 2 - optionsText.Width / 2, optionsText.Location.Y + optionsText.Height / 2);

            int resButtonSpacing = optionsGroup.Width;

            for(int i = 0; i < buttons.Length; i++)
                resButtonSpacing -= buttons[i].Width;

            resButtonSpacing /= (buttons.Length + 1);

            int prevButtonWidthTotal = 0;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Location = new Point(resButtonSpacing * (i + 1) + prevButtonWidthTotal, 100);
                prevButtonWidthTotal += buttons[i].Width;
            }
        }

    }
}
