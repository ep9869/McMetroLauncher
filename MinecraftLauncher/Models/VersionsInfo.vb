﻿Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class Natives
    Public Property linux() As String
        Get
            Return m_linux
        End Get
        Set(value As String)
            m_linux = value
        End Set
    End Property
    Private m_linux As String
    Public Property windows() As String
        Get
            Return m_windows
        End Get
        Set(value As String)
            m_windows = value
        End Set
    End Property
    Private m_windows As String
    Public Property osx() As String
        Get
            Return m_osx
        End Get
        Set(value As String)
            m_osx = value
        End Set
    End Property
    Private m_osx As String
End Class

Public Class Extract
    Public Property exclude() As List(Of String)
        Get
            Return m_exclude
        End Get
        Set(value As List(Of String))
            m_exclude = value
        End Set
    End Property
    Private m_exclude As List(Of String)
End Class

Public Class Os
    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Private m_name As String
End Class

Public Class Rule
    Public Property action() As String
        Get
            Return m_action
        End Get
        Set(value As String)
            m_action = value
        End Set
    End Property
    Private m_action As String
    Public Property os() As Os
        Get
            Return m_os
        End Get
        Set(value As Os)
            m_os = value
        End Set
    End Property
    Private m_os As Os
End Class

Public Class Library
    Public Property name As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
    Private m_name As String
    Public Property url As String
        Get
            Return m_url
        End Get
        Set(value As String)
            m_url = value
        End Set
    End Property
    Private m_url As String
    Public Property natives As Natives
        Get
            Return m_natives
        End Get
        Set(value As Natives)
            m_natives = value
        End Set
    End Property
    Private m_natives As Natives
    Public Property extract As Extract
        Get
            Return m_extract
        End Get
        Set(value As Extract)
            m_extract = value
        End Set
    End Property
    Private m_extract As Extract
    Public Property rules As List(Of Rule)
        Get
            Return m_rules
        End Get
        Set(value As List(Of Rule))
            m_rules = value
        End Set
    End Property
    Private m_rules As List(Of Rule)

    Public ReadOnly Property path As String
        Get
            '"java3d:vecmath:1.3.1"
            '<package>:<name>:<version>
            Dim nameparts As Array = name.Split(CChar(":"))
            Dim package As String = nameparts.GetValue(0).ToString
            Dim libname As String = nameparts.GetValue(1).ToString
            Dim version As String = nameparts.GetValue(2).ToString

            Dim filename As String = String.Join("-", libname, version)
            If natives IsNot Nothing Then
                '<name>-<version>-<native-string>.jar
                If natives.windows <> Nothing Then filename = filename.Insert(filename.Length, "-" & natives.windows)
            End If

            '<package>/<name>/<version>/<name>-<version>.jar
            Dim _path As String = String.Join("/", package.Replace(".", "/"), libname, version, filename) & ".jar"
            Return _path
        End Get
    End Property

End Class

Public Class VersionsInfo
    Public Property id() As String
        Get
            Return m_id
        End Get
        Set(value As String)
            m_id = value
        End Set
    End Property
    Private m_id As String
    Public Property time() As String
        Get
            Return m_time
        End Get
        Set(value As String)
            m_time = value
        End Set
    End Property
    Private m_time As String
    Public Property releaseTime() As String
        Get
            Return m_releaseTime
        End Get
        Set(value As String)
            m_releaseTime = value
        End Set
    End Property
    Private m_releaseTime As String
    Public Property type() As String
        Get
            Return m_type
        End Get
        Set(value As String)
            m_type = value
        End Set
    End Property
    Private m_type As String
    Public Property minecraftArguments() As String
        Get
            Return m_minecraftArguments
        End Get
        Set(value As String)
            m_minecraftArguments = value
        End Set
    End Property
    Private m_minecraftArguments As String
    Public Property libraries() As List(Of Library)
        Get
            Return m_libraries
        End Get
        Set(value As List(Of Library))
            m_libraries = value
        End Set
    End Property
    Private m_libraries As List(Of Library)
    Public Property mainClass() As String
        Get
            Return m_mainClass
        End Get
        Set(value As String)
            m_mainClass = value
        End Set
    End Property
    Private m_mainClass As String
    Public Property minimumLauncherVersion() As Integer
        Get
            Return m_minimumLauncherVersion
        End Get
        Set(value As Integer)
            m_minimumLauncherVersion = value
        End Set
    End Property
    Private m_minimumLauncherVersion As Integer
    Public Property assets() As String
        Get
            Return m_assets
        End Get
        Set(value As String)
            m_assets = value
        End Set
    End Property
    Private m_assets As String
    <JsonIgnore>
    Public Property JObject As JObject
        Get
            Return m_jobject
        End Get
        Set(value As JObject)
            m_jobject = value
        End Set
    End Property
    Private m_jobject As JObject
End Class