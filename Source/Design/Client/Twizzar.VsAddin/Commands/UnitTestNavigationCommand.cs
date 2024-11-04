﻿using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using EnvDTE;

using Microsoft.VisualStudio.Shell;

using Twizzar.Design.CoreInterfaces.Command.Services;
using Twizzar.Design.CoreInterfaces.TestCreation;
using Twizzar.SharedKernel.CoreInterfaces.Exceptions;
using Twizzar.SharedKernel.NLog.Logging;

using ViCommon.EnsureHelper;
using ViCommon.EnsureHelper.ArgumentHelpers.Extensions;
using ViCommon.Functional.Monads.MaybeMonad;

using TzUnitTestNavigationCommand = Twizzar.Design.CoreInterfaces.Command.Commands.UnitTestNavigationCommand;

namespace Twizzar.VsAddin.Commands
{
    /// <summary>
    /// Command handler.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal sealed class UnitTestNavigationCommand : ContextMenuCommand
    {
        #region fields

        /// <summary>
        /// Internal cqrs command bus.
        /// </summary>
        private readonly ICommandBus _commandBus;

        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestNavigationCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file).
        /// </summary>
        /// <param name="package">Acts as the service provider within the package.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        /// <param name="dte">Native document tools extensibility object.</param>
        /// <param name="commandBus">Internal cqrs command bus.</param>
        /// <param name="locationService"></param>
        private UnitTestNavigationCommand(
            AsyncPackage package,
            OleMenuCommandService commandService,
            DTE dte,
            ICommandBus commandBus,
            ILocationService locationService)
            : base(package, commandService, dte, locationService)
        {
            EnsureHelper.GetDefault.Many()
                .Parameter(commandBus, nameof(commandBus))
                .ThrowWhenNull();

            this._commandBus = commandBus;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static UnitTestNavigationCommand Instance { get; private set; }

        /// <inheritdoc />
        protected override int CommandId => 0x0101;

        /// <inheritdoc />
        protected override Guid CommandSet => new("436f4875-b65a-41e7-8dd4-71e95bfd4038");

        #endregion

        #region members

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandBus"></param>
        /// <param name="locationService"></param>
        /// <returns>A Task.</returns>
        public static async Task InitializeAsync(
            AsyncPackage package,
            ICommandBus commandBus,
            ILocationService locationService)
        {
            if (Instance != null)
            {
                var exp = new InternalException($"{nameof(UnitTestNavigationCommand)} is already Initialized");
                ViLog.Log(CallerContext.Create(), exp);
                throw exp;
            }

            // Switch to the main thread - the call to AddCommand in UnitTestNavigationCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            var dte = await package.GetServiceAsync(typeof(DTE)) as DTE;
            Instance = new UnitTestNavigationCommand(package, commandService, dte, commandBus, locationService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        protected override async void Execute(object sender, EventArgs e)
        {
            try
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

                await this.GetCurrentPosition()
                    .IfSomeAsync(async t =>
                    {
                        var command = new TzUnitTestNavigationCommand(t.FileName, t.CaretPosition, 0, 0);
                        await this._commandBus.SendAsync(command);
                    });
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        #endregion
    }
}