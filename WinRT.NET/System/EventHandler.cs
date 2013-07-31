﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
	/// <summary>
	/// Represents the method that will handle an event.
	/// </summary>
	/// <typeparam name="TEventArgs">The type of the event data generated by the event.</typeparam>
	/// <param name="sender">The object that generated the event.</param>
	/// <param name="e">Event data.</param>
	public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
}
