namespace Utilities.Mappers
{
    public interface IMapper<SourceModelObj, TargetModelObj>
    {
        public void Map(SourceModelObj sourceObj, ref TargetModelObj targetObj);
    }
}
