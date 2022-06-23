/// <copyright file="DataManager.cs" company="dachs.blog">
/// Copyright (c) 2014 - 2022 Holger Kühn. All rights reserved.
/// </copyright>
/// <summary>
/// Namespace used for all MediaServerManangement components
/// </summary>
namespace MediaServerManagement
{
    internal class JobUnknown : Job
    {
        #region Attributes

        private List<string> possibleCommands;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobUnknown"/> class.
        /// initializes configuration with last known configuration
        /// </summary>
        public JobUnknown(DataManager dataManager)
            : base(dataManager)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets list of possible commands<br/>
        /// </summary>
        /// <returns>list of possible commands</returns>
        public List<string> PossibleCommands
        {
            get
            {
                return this.possibleCommands;
            }

            set
            {
                this.possibleCommands = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// executes Job
        /// writes Message on Console
        /// </summary>
        /// <returns>error code of execution</returns>
        public override int ExecuteJob()
        {
            // declare variables
            string givenCommand;

            // set variables
            givenCommand = PossibleCommands.First();
            PossibleCommands.RemoveAt(0);

            Console.WriteLine("command \"" + givenCommand + "\" unknown");
            Console.WriteLine("use one of the following commands instead");
            
            foreach (string possibleCommand in PossibleCommands)
            {
                Console.WriteLine("  " + possibleCommand);
            };
            
            return 1;
        }

        #endregion
    }
}
