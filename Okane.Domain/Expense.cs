namespace Okane.Domain;

public class Expense
{

    //Homework Instruction:
    /*Modify the POST /expenses and GET /expenses endpoints, adding a Description property.*/
    public int Id { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; } // this will help us to add Description for Get and Post method
    public required string Category { get; set; }

    /*El archivo JSON debe tener el siguiente cuerpo, para que el metodo POST pueda funcionar:*/
    /*
        {
         "amount": 50,
          "description": "Compra de comestibles",
            "category": "Food"
        }

        Teniendo en cuenta, que aunque la clase Expense, tiene una propiedad "id" esta es creada en el Metodo Add que esta dentro de InmemoryExpenseReposi.. 
     */

}