using ExcecoesPersonalizadas.Entities;
using System;

namespace ExcecoesPersonalizadas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Check-in date (dd//MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Check-Out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());
           
            /* SOLUÇÃO RUIM:
            - Essa solução ainda é ruim porque:
                - A semântica da operação é prejudicada. (Porque a função de atualizar a reserva esta retornando uma string e isso não tem nada haver com a função pois o objetivo dela seria apenas atualizar os dados da reserva.)
                - E se a operação tivesse que retornar um string? (Isso poderia ocasionar um conflito com a string de erro)
            - Ainda não é possível tratar exceções em construtores.
            - A lógica fica estruturada em condicionais aninhadas.
             */
            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error in resenvation: Check-out date must be after check-in date!");
            }
            else
            {
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.WriteLine("Check-in date (dd//MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Check-Out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                //Nessa solução RUIM a lógica de testar as datas de reserva foi para a classe Reservation retornando uma string com o erro caso houver e nulo se não houver erro
                string error = reservation.UpdateDates(checkIn, checkOut);

                if(error != null) //If para testar se teve algum erro na verificação acima 
                {
                    Console.WriteLine("Error in reservation: " + error);
                }
                else //Se não teve nenhum erro de verificação irá mostrar os dados da reserva
                {
                    Console.WriteLine("Reservation: " + reservation);
                }
            }
        }
    }
}
