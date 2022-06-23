/// <copyright file="Program.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>

/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    /// <summary>
    /// Main Program
    /// manages the command line arguments and directs program work flow
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Program
        /// manages the command line arguments and directs program work flow
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            // initialize data
            DataManager dataManager = new DataManager();
            List<string> commandLineArguments = new List<string>();

            // convert array to List
            commandLineArguments = args.ToList<string>();

            // read command line arguments
            dataManager.Jobs.Add(Job.JobFactory(dataManager, commandLineArguments));
            dataManager.ExecuteJobs();
        }
    }
}