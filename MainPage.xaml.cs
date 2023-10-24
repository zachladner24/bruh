using CommunityToolkit.Maui.Views;
using System.Threading;

namespace CSC_317_Program_3_Idea_Morse_Code_Player;

public partial class MainPage : ContentPage
{
	/* This creates a class object of MorseEncoder, which
	 * is a class that accepts a message and converts it to 
	 * Morse Code. */
	MorseEncoder morseEncoder;
	public MainPage()
	{
		InitializeComponent();
		morseEncoder = new MorseEncoder();
	}

	/* This is the event function for the "Simulate" button.  
	 * You will need to set the button's Click event to this
	 * function. */
	private async void SimulateMorse(object sender, EventArgs e)
	{
		/*This is an example of playing a sound.
		 * Note that "dash" and "dot" are the Media Elements
		 * created in the front-end XAML code. 
		 * Modify this function so it translates the message
		 * correctly. */


		//Disable the button while the sounds are playing.
		btnSimulate.IsEnabled = false;
		user_input.IsEnabled = false;


		morseEncoder.Text = user_input.Text;
		output_label.Text = "";


		for (int i =0; i < morseEncoder.Morse.Length; i++)
		{
			if (i == '-')
			{
				await PlaySound(dash);
			}
		else if (i == '.')
			{
                await PlaySound(dot);
            }
			else
			{
                await Task.Delay(1000);
            }
           output_label.Text += morseEncoder.Morse[i];
		}

		//Once the sounds are finished, enable the button to allow running again.
		btnSimulate.IsEnabled = true;
		user_input.IsEnabled = true;
		
	   
	}

	/* This function should be called in the Click event function
	 * above.  DO NOT MODIFY!!! */
	private async Task PlaySound(MediaElement sound)
	{
		TimeSpan duration = sound.Duration;
		sound.Play();
		await Task.Delay(duration.Milliseconds + 200);

		return;
	}

}

