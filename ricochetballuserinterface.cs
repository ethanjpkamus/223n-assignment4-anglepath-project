//Author: Ethan Kamus
//email: ethanjpkamus@csu.fullerton.edu

//Purpose: to animate a "ball" moving across a straight path at a user input angle

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class ricochetballuserinterface : Form {

	//constants
	private const int MAXIMUM_FORM_WIDTH = 1000;
	private const int MAXIMUM_FORM_HEIGHT = 800;
	private const int BALL_OFFSET = 50;
	private const int FORM_X_CENTER = (MAXIMUM_FORM_WIDTH / 2) - BALL_OFFSET;
	private const int FORM_Y_CENTER = (MAXIMUM_FORM_HEIGHT / 2) - BALL_OFFSET;

	//variables
	private int ball_xpos = FORM_X_CENTER;
	private int ball_ypos = FORM_Y_CENTER;

	//items to be used in the user interface
	private Button play_pause_button = new Button();
	private Button reset_button = new Button();
	private Button exit_button = new Button();

	private TextBox speed_input_box = new TextBox();
	private TextBox angle_input_box = new TextBox();

	private Label label_xpos = new Label();
	private Label label_ypos = new Label();

	private static System.Timers.Timer ui_clock = new System.Timers.Timer();
	private static System.Timers.Timer ball_clock = new System.Timers.Timer();

	//constructor
	public ricochetballuserinterface(){

		MaximumSize = new Size(MAXIMUM_FORM_WIDTH,MAXIMUM_FORM_HEIGHT);
		MinimumSize = new Size(MAXIMUM_FORM_WIDTH,MAXIMUM_FORM_HEIGHT);

		ui_clock.Interval = 33;
		ui_clock.Enabled = true;
		ui_clock.AutoReset = true;

		ball_clock.Interval = 33;
		ball_clock.Enabled = false;
		ball_clock.AutoReset = true;

		Text = "Ricochet Ball Project by: Ethan Kamus";

		play_pause_button.Text = "GO!";
		reset_button.Text = "RESET";
		exit_button.Text = "EXIT";

		play_pause_button.Size = new Size(75,30);
            	reset_button.Size = new Size(75,30);
            	exit_button.Size = new Size(75,30);
            	label_xpos.Size = new Size(75,30);
            	label_ypos.Size = new Size(75,30);

		play_pause_button.Location = new Point(0,0);
            	reset_button.Location = new Point(0,40);
            	exit_button.Location = new Point(0,80);
            	label_xpos.Location = new Point(0,120);
            	label_ypos.Location = new Point(0,160);

		Controls.Add(play_pause_button);
            	Controls.Add(reset_button);
            	Controls.Add(exit_button);
            	Controls.Add(label_xpos);
            	Controls.Add(label_ypos);

		//timer eventhandlers
            	ui_clock.Elapsed += new ElapsedEventHandler(update_ui);
	       ball_clock.Elapsed += new ElapsedEventHandler(update_ball_pos);

            	//Button evenhandlers
            	play_pause_button.Click += new EventHandler(update_play_pause);
            	reset_button.Click += new EventHandler(update_reset);
            	exit_button.Click += new EventHandler(update_exit);

	} //end of constructor

	protected override void OnPaint(PaintEventArgs e){

		Graphics graph = e.Graphics;



	} //end of OnPaint override

	protected void update_ui(Object o, ElapsedEventArgs e){

		Invalidate();

	} //end of update_ui

	protected void update_ball_pos(Object o, ElapsedEventArgs e){

	} //end of update_ball_pos

	protected void update_play_pause(Object o, EventArgs e){

		ball_clock.Enabled = !ball_clock.Enabled;

		//get user input for speed from TextBox

		//get user input for angle from TextBox

	} //end of update_play_pause

	protected void update_reset(Object o, EventArgs e){

		ball_clock.Enabled = false;
		ball_xpos = FORM_X_CENTER;
		ball_ypos = FORM_Y_CENTER;

	} //end of update_reset

	protected void update_exit(Object o, EventArgs e){

		Close();

	} //end of update_exit

} //end of ricochetballuserinterface implementation
