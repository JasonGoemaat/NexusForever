﻿namespace NexusForever.Script.Template.Filter
{
    public interface IScriptFilterSearch
    {
        Type ScriptType { get; }
        uint? Id { get; }
        uint? CreatureId { get; }
        uint? TargetGroupId { get; }
        ulong? ActivePropId { get; }
        List<string> ScriptNames { get; }

        IScriptFilterSearch FilterByScriptType<T>() where T : IScript;
        IScriptFilterSearch FilterById(uint id);
        IScriptFilterSearch FilterByCreatureId(uint id);
        IScriptFilterSearch FilterByTargetGroupId(uint id);
        IScriptFilterSearch FilterByActivePropId(ulong id);
        IScriptFilterSearch FilterByScriptNames(List<string> scriptNames);
    }
}