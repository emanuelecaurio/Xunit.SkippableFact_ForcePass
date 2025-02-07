﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Microsoft Public License (Ms-PL). See LICENSE.txt file in the project root for full license information.

namespace Xunit.SkippableFact.Tests;

public class SkipTests
{
    [Fact]
    public void If()
    {
        Assert.Throws<SkipException>(() => Skip_ForcePass.If(true));
        Skip_ForcePass.If(false);
    }

    [Fact]
    public void If_WithReason()
    {
        string reason = "some reason";
        try
        {
            Skip_ForcePass.If(true, reason);
            Assert.Fail("If should have thrown.");
        }
        catch (SkipException ex)
        {
            Assert.Equal(reason, ex.Message);
        }
    }

    [Fact]
    public void IfNot()
    {
        Assert.Throws<SkipException>(() => Skip_ForcePass.IfNot(false));
        Skip_ForcePass.IfNot(true);
    }

    [Fact]
    public void IfNot_WithReason()
    {
        string reason = "some reason";
        try
        {
            Skip_ForcePass.IfNot(false, reason);
            Assert.Fail("IfNot should have thrown.");
        }
        catch (SkipException ex)
        {
            Assert.Equal(reason, ex.Message);
        }
    }

    [Fact]
    public void If_SupportsNullableReferenceTypesPostCondition()
    {
        // Provoke a possibly null value that is not detectable through
        // static analysis
        string? value =
            int.Parse("42", System.Globalization.CultureInfo.InvariantCulture) == 42
            ? "Not null"
            : null;

        Skip_ForcePass.If(value is null);

        // Does not trigger a nullable reference type warning
        _ = value.Substring(0);
    }

    [Fact]
    public void IfNot_SupportsNullableReferenceTypesPostCondition()
    {
        // Provoke a possibly null value that is not detectable through
        // static analysis
        string? value =
            int.Parse("42", System.Globalization.CultureInfo.InvariantCulture) == 42
            ? "Not null"
            : null;

        Skip_ForcePass.IfNot(value is object);

        // Does not trigger a nullable reference type warning
        _ = value.Substring(0);
    }
}
