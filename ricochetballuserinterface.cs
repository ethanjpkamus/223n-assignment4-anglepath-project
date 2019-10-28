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
	private const int BALL_RADIUS = 50;
	private const int FORM_X_CENTER = (MAXIMUM_FORM_WIDTH / 2) - BALL_RADIUS;
	private const int FORM_Y_CENTER = (MAXIMUM_FORM_HEIGHT / 2) - BALL_RADIUS;

	//variables
	private int ball_xpos = FORM_X_CENTER;
	private int ball_ypos = FORM_Y_CENTER;
	private int delta_x = 0;
	private int delta_y = 0;

	private double speed = 1.0;
	private double angle = 1.0;
	private double pix_per_tic = 1.0;

	private bool once = true;

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

		ball_clock.Interval = 20;
		ball_clock.Enabled = false;
		ball_clock.AutoReset = true;

		Text = "Ricochet Ball Project by: Ethan Kamus";

		play_pause_button.Text = "GO!";
		reset_button.Text = "RESET";
		exit_button.Text = "EXIT";

		speed_input_box.Text = "pix/sec";
		angle_input_box.Text = "degrees";

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

		Controls.Add(speed_input_box);
		Controls.Add(angle_input_box);

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

		graph.FillEllipse(brushes.Red,ball_xpos,ball_ypos,2*BALL_RADIUS,2*BALL_RADIUS);

	} //end of OnPaint override

	protected void update_ui(Object o, ElapsedEventArgs e){

		Invalidate();

	} //end of update_ui

	protected void update_ball_pos(Object o, ElapsedEventArgs e){

		manage_delta();
		ball_xpos += delta_x;
		ball_ypos += delta_y;

	} //end of update_ball_pos

	protected void update_play_pause(Object o, EventArgs e){

		ball_clock.Enabled = !ball_clock.Enabled;

		//change the text of the Button
		if(ball_clock.Enabled){
			play_pause_button.Text = "Pause";
		} else {
			play_pause_button.Text = "Play";
		}

		if(once){
			once = false;
			speed = Double.Parse(speed_input_box.Text);
			angle = Double.Parse(angle_input_box.Text);
			pix_per_tic = speed / (ball_clock.Interval * 1000);
		}

	} //end of update_play_pause

	protected void update_reset(Object o, EventArgs e){

		ball_clock.Enabled = false;
		once = true;
		ball_xpos = FORM_X_CENTER;
		ball_ypos = FORM_Y_CENTER;

		//reset textboxes
		speed_input_box.Text = "pix/sec";
		angle_input_box.Text = "degrees";

	} //end of update_reset

	protected void update_exit(Object o, EventArgs e){

		Close();

	} //end of update_exit

	private void manage_delta(){

		//check for ricochet
		if(ball_xpos == 0){

		} else if(ball_xpos == (MAXIMUM_FORM_WIDTH - (2*BALL_RADIUS))){

		} else if(){

		} else if(){

		}
	} //end of manage delta

} //end of ricochetballuserinterface implementation
