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
                var std = new Student()
                {
                    FirstName = "Erisson",
                    LastName = "Silverio",

                };

                context.students.Add(std);
                context.SaveChanges();

            }


                                                    //---Ejemplo Actualizar Datos
            using (var context = new Contexto())
            {
                var std = context.students.First<Student>();
                std.FirstName = "Silverio";
                context.SaveChanges();
            }



                                                    //-----Ejemplo Eliminar Datos
            using (var context = new Contexto())
            {
                var std = context.students.First<Student>();
                context.students.Remove(std);

               

                context.SaveChanges();
            }



            //---Ejemplo Consultando Datos

            var context_S = new Contexto();
            var studentsWithSameName = context_S.students
                                              .Where(s => s.FirstName == GetName())
                                              .ToList();
        }

        public static string GetName()
        {
            return "Erisson";
          
        }

        

    }
}
