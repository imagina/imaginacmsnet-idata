using System.Reflection;
using Ihelpers.Extensions;
namespace Idata.Helpers
{
    public class EntitiesHelper
    {

        /// <summary>
        /// Asynchronously stores the path of all classes inside Idata assembly that inherit from the EntityBase class and are located in the Idata.Data.Entities namespace, in the cache container located in Ihelper.
        /// </summary>
        /// <returns></returns>
        public static async Task StoreClassesPath()
        {

            // Retrieve all classes in the current executing assembly that inherit from the EntityBase class and are located in the Idata.Data.Entities namespace. and store inside cache
            var allClasses = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.IsClass && a.BaseType.Name == "EntityBase" && a.Namespace != null && a.Namespace.Contains(@"Idata.Data.Entities")).ToList();

            ConfigContainer.cache.CreateValue($"AllClasses", allClasses, 43.200);

        }


        /// <summary>
        /// Gets the first class that is a subclass of EntityBase in the Idata.Data.Entities namespace 
        /// and whose namespace contains one or more of the specified arguments.
        /// </summary>
        /// <param name="input">The input string containing one or more comma-separated arguments.</param>
        /// <returns>The first class that matches the specified criteria, or null if no class is found.</returns>
        public static async Task<Type?> GetClassBy(string input)
        {
            // Split the input string into individual arguments, if necessary
            List<string> arguments = new List<string>();

            if (input.Contains(','))
            {
                arguments = input.Split(',').ToList();
            }
            else
            {
                arguments.Add(input);
            }

            // Query for classes that meet the specified criteria
            var clasesQuery = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.IsClass && a.BaseType.Name == "EntityBase"
                    && a.Namespace != null && a.Namespace.Contains(@"Idata.Data.Entities"));

            // Narrow the query results by filtering by each argument in the list
            foreach (var argument in arguments)
            {
                clasesQuery = clasesQuery.Where(a => a.Namespace.ToLower().Contains(argument.ToLower()));
            }

            // Return the first matching class, or null if no match is found
            return clasesQuery.FirstOrDefault();
        }
    }
}
