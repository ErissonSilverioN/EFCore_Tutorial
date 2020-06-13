using System;
using System.Linq;
using EFCoreTutorials.DAL;
using EFCoreTutorials.Models;


namespace EFCoreTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
                                                     //---Ejemplo Isertar Datos

            using (var context = new Contexto())
            {
                var insertar = new Student()
                {
                    FirstName = "Erisson",
                    LastName = "Silverio",

                };

                context.students.Add(insertar);
                context.SaveChanges();

            }


                                                    //---Ejemplo Actualizar Datos
            using (var context = new Contexto())
            {
                var actualizar = context.students.First<Student>();
                actualizar.FirstName = "Silverio";
                context.SaveChanges();
            }



                                                    //-----Ejemplo Eliminar Datos
            using (var context = new Contexto())
            {
                var eliminar = context.students.First<Student>();
                context.students.Remove(eliminar);

               

                context.SaveChanges();
            }



                                                  //---Ejemplo Consultando Datos

            var context_C = new Contexto();
            var studentsWithSameName = context_C.students
                                              .Where(s => s.FirstName == GetName())
                                              .ToList();







                                                   //---- Guardando datos en escenario desconectado

            var guardar = new Student() { FirstName = "Guilen" };

            using (var context = new Contexto())
            {
                context.Add<Student>(guardar);
                context.SaveChanges();
            }




            //------Insertar datos relacionales



            var stdAddress= new Address()
            {
                City = "SFO",
                State = "CA",
                Country = "USA"

            };

            var std = new Student()
            {
                FirstName = "Julio",
                Address = Convert.ToString(stdAddress),

            };


            using (var contex = new Contexto())
            {
                contex.Add<Student>(std);
                contex.SaveChanges();
            }



                                           //-----Insertar datos  yusando DbSet

            var insertar_dbset = new  Student()
            {
                FirstName = "Bill"
            };

            using (var context = new Contexto())
            {
                context.students.Add(insertar_dbset);
                context.SaveChanges();
            }



        }

        public static string GetName()
        {
            return "Erisson";
          
        }

        

    }
}
