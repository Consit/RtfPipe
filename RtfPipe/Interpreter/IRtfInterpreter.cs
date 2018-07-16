﻿using System;

namespace RtfPipe
{

  public interface IRtfInterpreter
  {

    /// <summary>
    /// The settings used by the interpreter.
    /// </summary>
    IRtfInterpreterSettings Settings { get; }

    /// <summary>
    /// Adds a listener that will get notified along the interpretation process.
    /// </summary>
    /// <param name="listener">the listener to add</param>
    /// <exception cref="ArgumentNullException">in case of a null argument</exception>
    void AddInterpreterListener(IRtfInterpreterListener listener);

    /// <summary>
    /// Removes a listener from this instance.
    /// </summary>
    /// <param name="listener">the listener to remove</param>
    /// <exception cref="ArgumentNullException">in case of a null argument</exception>
    void RemoveInterpreterListener(IRtfInterpreterListener listener);

    /// <summary>
    /// Parses the given RTF document and informs the registered listeners about
    /// all occurring events.
    /// </summary>
    /// <param name="rtfDocument">the RTF documet to interpret</param>
    /// <exception cref="RtfException">in case of an unsupported RTF structure</exception>
    /// <exception cref="ArgumentNullException">in case of a null argument</exception>
    void Interpret(IRtfGroup rtfDocument);

  }

}