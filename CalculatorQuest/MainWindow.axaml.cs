using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Data;

namespace CalculatorQuest;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public string calcul;
    private void AddInput(object sender, RoutedEventArgs e) {
        var button = sender as Button;
        var value = button.Tag.ToString();
        calcul+= value;
        op.Content = calcul;
    }

    private void Equal(object sender, RoutedEventArgs e){
        result.Content = Result();
    }   
    private void C(object sender, RoutedEventArgs e){
        calcul = "";
        op.Content = "";
    }
    private void CE(object sender, RoutedEventArgs e){
        calcul = "";
        op.Content = "";
        result.Content = "";
    }
    private void Del(object sender, RoutedEventArgs e){
        if(calcul.Length != 0){
            calcul = calcul.Remove(calcul.Length-1);
            op.Content = calcul;
        }
    }
    public string Result() {
        if (string.IsNullOrWhiteSpace(calcul)) {
                return "L'expression est vide";
        }
        try {  
            var dataTable = new DataTable();
            return Convert.ToDouble(dataTable.Compute(calcul, string.Empty)).ToString();
        }
        catch (DivideByZeroException) {
            return "Erreur : Division par 0"; 
        }
        catch (Exception ex) {
            return "Erreur";
        }
    }
}