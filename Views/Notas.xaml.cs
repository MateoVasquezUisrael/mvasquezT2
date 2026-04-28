using System.Numerics;

namespace mvasquezT2.Views;

public partial class Notas : ContentPage
{
	public Notas()
	{
		InitializeComponent();
	}

    private async void Button_Pressed(object sender, EventArgs e)
    {
		try {

			double firstNote;
			double secondNote;
			double thirdNote;
			double fourthNote;
			double partialNote1;
			double partialNote2;
			double totalNote;

            string estado;
			if(StudentPicker.SelectedIndex == -1)
			{
                await DisplayAlertAsync("Aviso", "Seleccione un estudiante", "OK");
				return;
            }

			if (!double.TryParse(FirstNoteInput.Text, out firstNote)){ 
                await DisplayAlertAsync("Aviso", "Ingrese nota seguimiento 1", "OK");
                return;
            }

            if (firstNote > 10 || firstNote <0)
            {
                DisplayAlertAsync("Aviso", "Ingrese un numero valido", "OK");
                return;
            }
 

            firstNote *= 0.3;


            if (!double.TryParse(SecondNoteInput.Text, out secondNote))
            {
                await DisplayAlertAsync("Aviso", "Ingrese nota de parcial 1", "OK");
                return;
            }

            if (secondNote > 10 || secondNote < 0)
            {
                DisplayAlertAsync("Aviso", "Ingrese un numero valido", "OK");
                return;
            }
            secondNote *= 0.2;

			partialNote1 = firstNote + secondNote;

			FirstFinalNote.Text = partialNote1.ToString();


            if (!double.TryParse(ThirdNoteInput.Text, out thirdNote))
            {
                await DisplayAlertAsync("Aviso", "Ingrese nota seguimiento 1", "OK");
                return;
            }

            if (thirdNote > 10 || thirdNote < 0)
            {
                DisplayAlertAsync("Aviso", "Ingrese un numero valido", "OK");
                return;
            }

            thirdNote *= 0.3;


            if (!double.TryParse(FourthNoteInput.Text, out fourthNote))
            {
                await DisplayAlertAsync("Aviso", "Ingrese nota de parcial 1", "OK");
                return;
            }

            if (fourthNote > 10 || fourthNote < 0)
            {
                DisplayAlertAsync("Aviso", "Ingrese un numero valido", "OK");
                return;
            }

            fourthNote *= 0.2;

            partialNote2 = thirdNote + fourthNote;

            SecondFinalNote.Text = partialNote2.ToString();

            totalNote = partialNote1 + partialNote2;

            FinalNote.Text = totalNote.ToString();

            switch (totalNote)
            {
                case >= 7:
                    estado = "APROBADO";
                    break;
                case >= 5 and <= 6.9:
                    estado = "COMPLEMENTARIO";
                    break;
                default:
                    estado = "REPROBADO";
                    break;
            }

            await DisplayAlert("Resultado", $"Nombre:{StudentPicker.SelectedIndex.ToString()}\n Fecha:Fecha:{datePickerMio.Date:dd/MM/yyyy}\n Nota Parcial 1: {partialNote1}\n Nota Parcial 2: {partialNote2}\n Nota final: {totalNote:F2} - {estado}", "OK");
        }
		catch (Exception err) {

            await DisplayAlert("Error", err.Message, "OK");
        }
    }
}