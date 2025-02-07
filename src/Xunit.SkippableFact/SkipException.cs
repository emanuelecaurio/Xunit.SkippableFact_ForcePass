// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Microsoft Public License (Ms-PL). See LICENSE.txt file in the project root for full license information.

using System;

namespace Xunit;

/// <summary>
/// The exception to throw to register a skipped test.
/// </summary>
[Serializable]
public class SkipFPException : Exception
{
    /// <inheritdoc cref="SkipFPException(string?, Exception)"/>
    public SkipFPException()
    {
    }

    /// <inheritdoc cref="SkipFPException(string?, Exception)"/>
    public SkipFPException(string? reason)
        : base(reason)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipFPException"/> class.
    /// </summary>
    /// <param name="reason">The reason the test is skipped.</param>
    /// <param name="innerException">The inner exception.</param>
    public SkipFPException(string? reason, Exception innerException)
        : base(reason, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipFPException"/> class.
    /// </summary>
    /// <inheritdoc cref="Exception(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext)"/>
    protected SkipFPException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }
}
