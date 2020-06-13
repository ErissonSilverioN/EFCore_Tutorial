using System;
using System.Collections.Generic;
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


                                                  //-----Actualizando datos en un escenario desconectado

            var stud = new Student() { StudentId = 1, FirstName = "Guilen" };

            stud.FirstName = "Steve";

            using (var context = new Contexto())
            {
                context.Update<Student>(stud);

               
                context.SaveChanges();
            }


                                                        //------Actualizar múltiples entidades

            var modifiedStudent1 = new Student()
            {
                StudentId = 1,
                FirstName = "Bill"
            };

            var modifiedStudent2 = new Student()
            {
                StudentId = 3,
                FirstName = "Steve"
            };

            var modifiedStudent3 = new Student()
            {
                StudentId = 3,
                FirstName = "James"
            };

            IList<Student> modifiedStudents = new List<Student>()
            {
                modifiedStudent1,
                modifiedStudent2,
                modifiedStudent3
            };

            using (var context = new Contexto())
            {
                context.UpdateRange(modifiedStudents);

      
                context.SaveChanges();
            }





                              //-----Eliminar datos en un escenario desconectado 
            var student = new Student()
            {
                StudentId = 1
            };

            using (var context = new Contexto())
            {
                context.Remove<Student>(student);

                 context.SaveChanges();
            }




                                                       //------Eliminar múltiples registros
            IList<Student> students = new List<Student>() {
               new Student(){ StudentId = 1 },
               new Student(){ StudentId = 2 },
               new Student(){ StudentId = 3 },
               
             };

            using (var context = new Contexto())
            {
                context.RemoveRange(students);

                context.SaveChanges();
            }




        }

        public static string GetName()
        {
            return "Erisson";
          
        }

        

    }
}
