using System;
#if SERIALIZATION
using System.Runtime.Serialization;
#endif

namespace RtfPipe
{


  /// <summary>Thrown upon RTF specific error conditions.</summary>
#if SERIALIZATION
  [Serializable]
#endif
  public class RtfUndefinedColorException : RtfInterpreterException
  {

    /// <summary>Creates a new instance.</summary>
    public RtfUndefinedColorException()
    {
    }

    /// <summary>Creates a new instance with the given message.</summary>
    /// <param name="message">the message to display</param>
    public RtfUndefinedColorException( string message ) :
      base( message )
    {
    }

    /// <summary>Creates a new instance with the given message, based on the given cause.</summary>
    /// <param name="message">the message to display</param>
    /// <param name="cause">the original cause for this exception</param>
    public RtfUndefinedColorException( string message, Exception cause ) :
      base( message, cause )
    {
    }

#if SERIALIZATION
    /// <summary>Serialization support.</summary>
    /// <param name="info">the info to use for serialization</param>
    /// <param name="context">the context to use for serialization</param>
    protected RtfUndefinedColorException( SerializationInfo info, StreamingContext context ) :
      base( info, context )
    {
    }
#endif

  }

}
