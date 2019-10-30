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
	private const int MAXIMUM_FORM_HEIGHT = 800; //inner rectangle is 500
	private const int BALL_RADIUS = 20;
	private const int FORM_X_CENTER = (MAXIMUM_FORM_WIDTH / 2) - BALL_RADIUS;
	private const int FORM_Y_CENTER = (MAXIMUM_FORM_HEIGHT / 2) - 50 - BALL_RADIUS;

	//variables
	private int ball_xpos = FORM_X_CENTER;
	private int ball_ypos = FORM_Y_CENTER;
	private int delta_x = 0;
	private int delta_y = 0;

	private double speed = 10.0;
	private double angle = 30.0;
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

		label_xpos.Text = "X-Pos: Center";
		label_ypos.Text = "Y-Pos: Center";

		play_pause_button.Size = new Size(75,30);
            	reset_button.Size = new Size(75,30);
            	exit_button.Size = new Size(75,30);
		speed_input_box.Size = new Size(75,30);
		angle_input_box.Size = new Size(75,30);
            	label_xpos.Size = new Size(75,30);
            	label_ypos.Size = new Size(75,30);

		play_pause_button.Location = new Point(0,650);
            	reset_button.Location = new Point(100,650);
            	exit_button.Location = new Point(200,650);
		speed_input_box.Location = new Point(300,650);
		angle_input_box.Location = new Point(400,650);
            	label_xpos.Location = new Point(500,600);
            	label_ypos.Location = new Point(500,700);

		label_xpos.BackColor = Color.Green;
		label_xpos.ForeColor = Color.Yellow;

		label_ypos.BackColor = Color.Green;
		label_ypos.ForeColor = Color.Yellow;

		Controls.Add(play_pause_button);
            	Controls.Add(reset_button);
            	Controls.Add(exit_button);
            	Controls.Add(label_xpos);
            	Controls.Add(label_ypos);

		Controls.Add(speed_input_box);
		Controls.Add(angle_input_box);label_xpos.BackColor = Color.Green;
		label_xpos.ForeColor = Color.Yellow;

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

		graph.FillEllipse(Brushes.Red,ball_xpos,ball_ypos,2*BALL_RADIUS,2*BALL_RADIUS);
		graph.FillRectangle(Brushes.Yellow,0,0,1000,100);
		graph.FillRectangle(Brushes.Green,0,600,1000,200);

		label_xpos.Text = "X-Pos: " + (ball_xpos + BALL_RADIUS).ToString();
		label_ypos.Text = "Y-Pos: " + (ball_ypos + BALL_RADIUS).ToString();

	} //end of OnPaint override

	//executes when the ui_clock elapses
	protected void update_ui(Object o, ElapsedEventArgs e){

		Invalidate();

	} //end of update_ui

	//executes when the ball_clock elapses
	protected void update_ball_pos(Object o, ElapsedEventArgs e){

		check_collision();
		ball_xpos += delta_x;
		ball_ypos += delta_y;

	} //end of update_ball_pos

	//executes when the play_pause_button is clicked
	protected void update_play_pause(Object o, EventArgs e){

		if(once){
		//will only execute once when the user enters a speed and angle

			speed = Double.Parse(speed_input_box.Text);
			angle = Double.Parse(angle_input_box.Text);
			pix_per_tic = speed / (ball_clock.Interval * 1000);

			delta_x = (int)(System.Math.Sin(angle) * pix_per_tic);
			delta_y = (int)(System.Math.Cos(angle) * pix_per_tic * -1);
			once = false;
		}

		ball_clock.Enabled = !(ball_clock.Enabled);

		//change the text of the Button
		if(ball_clock.Enabled){

			play_pause_button.Text = "Pause";

		} else {

			play_pause_button.Text = "Play";

		}

	} //end of update_play_pause

	//executes when the reset_button is clicked
	protected void update_reset(Object o, EventArgs e){

		ball_clock.Enabled = false;
		once = true;
		ball_xpos = FORM_X_CENTER;
		ball_ypos = FORM_Y_CENTER;

		//reset textboxes
		speed_input_box.Text = "pix/sec";
		angle_input_box.Text = "degrees";

	} //end of update_reset

	//executes when the exit_button is clicked
	protected void update_exit(Object o, EventArgs e){

		Close();

	} //end of update_exit

	//checks if the ball has hit one of the edges of the rectangle
	private void check_collision(){

		//check for ricochet
		if(ball_xpos == 0){
		//left side of window
			delta_x = -1 * delta_x;
		} else if(ball_xpos == (MAXIMUM_FORM_WIDTH - (2*BALL_RADIUS))){
		//right side of window
			delta_x = -1 * delta_x;
		} else if(ball_ypos == 0){
		//top of window
			delta_y = -1 * delta_y;
		} else if(ball_ypos == (MAXIMUM_FORM_HEIGHT - (2*BALL_RADIUS))){
		//bottom of window
			delta_y = -1 * delta_y;
		}
	} //end of manage delta

} //end of ricochetballuserinterface implementation
