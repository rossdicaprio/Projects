using System.Windows.Forms;
using System.Drawing;
using Model;

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
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location)
            };

            Button startButton = new Button()
            {
                Text = "Start",
                Location = new Point(210, 10)
            };
            Button optionsButton = new Button()
            {
                Text = "Options",
                Location = new Point(110, 10)
            };
            Button exitButton = new Button()
            {
                Text = "Exit",
                Location = new Point(10, 10)
            };

            #region Option Menu Setup
            GroupBox optionsGroup = new GroupBox();

            Label optionsText = new Label();
            optionsText.Text = "Options";

            Button optionsBack = new Button();
            Button res640x480 = new Button();
            Button res1024x576 = new Button();
            Button res1280x960 = new Button();
            Button res1600x900 = new Button();
            Button fullscreen = new Button();
            Button windowed = new Button();

            optionsBack.Text = "Back";
            res640x480.Text = "640x480";
            res1024x576.Text = "1024x576";
            res1280x960.Text = "1280x960";
            res1600x900.Text = "1600x900";
            fullscreen.Text = "Fullscreen";
            windowed.Text = "Windowed";

            res640x480.Enabled = false; // Default
            windowed.Enabled = false;   // Default

            optionsBack.Click += (o, s) =>
            {
                optionsButton.Enabled = true;
                optionsGroup.Visible = false;
            };

            res640x480.Click += (o, s) =>
            {
                res640x480.Enabled = false;
                res1024x576.Enabled = true;
                res1280x960.Enabled = true;
                res1600x900.Enabled = true;
                
                form.Size = new Size(640, 480);

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1024x576.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = false;
                res1280x960.Enabled = true;
                res1600x900.Enabled = true;

                form.Size = new Size(1024, 576);

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1280x960.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = true;
                res1280x960.Enabled = false;
                res1600x900.Enabled = true;

                form.Size = new Size(1280, 960);

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            res1600x900.Click += (o, s) =>
            {
                res640x480.Enabled = true;
                res1024x576.Enabled = true;
                res1280x960.Enabled = true;
                res1600x900.Enabled = false;

                form.Size = new Size(1600, 900);

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            fullscreen.Click += (o, s) =>
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;

                res640x480.Enabled = false;
                res1024x576.Enabled = false;
                res1280x960.Enabled = false;
                res1600x900.Enabled = false;

                fullscreen.Enabled = false;
                windowed.Enabled = true;

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            windowed.Click += (o, s) =>
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.WindowState = FormWindowState.Normal;

                if (form.Size.Width == 640 && form.Size.Height == 480)
                {
                    res640x480.Enabled = false;
                    res1024x576.Enabled = true;
                    res1280x960.Enabled = true;
                    res1600x900.Enabled = true;
                }
                else if (form.Size.Width == 1024 && form.Size.Height == 576)
                {
                    res640x480.Enabled = true;
                    res1024x576.Enabled = false;
                    res1280x960.Enabled = true;
                    res1600x900.Enabled = true;
                }
                else if (form.Size.Width == 1280 && form.Size.Height == 960)
                {
                    res640x480.Enabled = true;
                    res1024x576.Enabled = true;
                    res1280x960.Enabled = false;
                    res1600x900.Enabled = true;
                }
                else if (form.Size.Width == 1600 && form.Size.Height == 900)
                {
                    res640x480.Enabled = true;
                    res1024x576.Enabled = true;
                    res1280x960.Enabled = true;
                    res1600x900.Enabled = false;
                }

                fullscreen.Enabled = true;
                windowed.Enabled = false;

                UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);
            };

            optionsGroup.Controls.Add(optionsText);
            optionsGroup.Controls.Add(optionsBack);
            optionsGroup.Controls.Add(res640x480);
            optionsGroup.Controls.Add(res1024x576);
            optionsGroup.Controls.Add(res1280x960);
            optionsGroup.Controls.Add(res1600x900);
            optionsGroup.Controls.Add(fullscreen);
            optionsGroup.Controls.Add(windowed);

            UpdateOptionMenu(form, optionsGroup, optionsText, optionsBack, fullscreen, windowed, res640x480, res1024x576, res1280x960, res1600x900);

            form.Controls.Add(optionsGroup);

            optionsGroup.Visible = false; // Hide the options menu
            #endregion

            startButton.Click += (o, s) =>
            {
                GameManager manager = new GameManager();
                startButton.Enabled = false;
            };

            optionsButton.Click += (o, s) =>
            {
                optionsButton.Enabled = false;
                optionsGroup.Visible = true;
            };

            exitButton.Click += (o, s) =>
            {
                System.Windows.Forms.Application.Exit();
            };

            form.Controls.Add(startButton);
            form.Controls.Add(optionsButton);
            form.Controls.Add(exitButton);
            form.ShowDialog();

            //while (form.Created){}
        }

        /// <summary>
        /// Updates the sizes and locations of the items in the option menu to fit the window size
        /// </summary>
        private static void UpdateOptionMenu(Form form, GroupBox optionsGroup, Label optionsText, Button back, Button fullscreen, Button windowed, params Button[] buttons)
        {
            // Set the form location to the middle of the screen
            form.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - form.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - form.Height) / 2);

            // Center the option group depending on the border style
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

            // Center the options text horizontally
            optionsText.TextAlign = ContentAlignment.MiddleCenter;
            optionsText.Location = new Point(optionsGroup.Width / 2 - optionsText.Width / 2, optionsText.Height / 2);

            // Set back button location to top right of option menu
            back.Location = new Point(optionsGroup.Width - back.Width - 10, back.Height / 2);

            // Calculate the spacing between all of the resolution buttons
            int resButtonSpacing = optionsGroup.Width;

            for(int i = 0; i < buttons.Length; i++)
                resButtonSpacing -= buttons[i].Width;

            resButtonSpacing /= (buttons.Length + 1);

            // Calculate and set each resolution button location
            int prevButtonWidthTotal = 0;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Location = new Point(resButtonSpacing * (i + 1) + prevButtonWidthTotal, 100);
                prevButtonWidthTotal += buttons[i].Width;
            }

            fullscreen.Location = new Point(optionsGroup.Width / 3 - optionsText.Width / 2, 200);
            windowed.Location = new Point(optionsGroup.Width * 2 / 3 - optionsText.Width / 2, 200);
        }
    }
}