using Moq;
using NUnit.Framework;
using SolidWorks.Interop.sldworks;

namespace CADBooster.SolidDna.Test;

[TestFixture]
internal class ModelFeatureTest
{
    [Test]
    public void Constructor_FromNull_DoesNotThrow()
    {
        var modelFeature = new ModelFeature(null);

        Assert.That(modelFeature, Is.Not.Null);
        Assert.That(modelFeature.UnsafeObject, Is.Null);
    }

    [Test]
    public void Constructor_DoesNotCallSpecificFeatureOrDefinition()
    {
        var feature = new Mock<Feature>(MockBehavior.Strict);

        var modelFeature = new ModelFeature(feature.Object);

        Assert.That(modelFeature.UnsafeObject, Is.EqualTo(feature.Object));
        feature.Verify(x => x.GetSpecificFeature2(), Times.Never);
        feature.Verify(x => x.GetDefinition(), Times.Never);
    }

    [Test]
    public void CreateOrNull_FromFeature_SetsProperties()
    {
        var feature = new Mock<Feature>(MockBehavior.Strict);
        var specificFeature = new Mock<IAttribute>();
        var featureData = new Mock<IGroundPlaneFeatureData>();
        feature.Setup(x => x.GetSpecificFeature2()).Returns(specificFeature.Object);
        feature.Setup(x => x.GetDefinition()).Returns(featureData.Object);

        var modelFeature = new ModelFeature(feature.Object);

        Assert.That(modelFeature, Is.Not.Null);
        Assert.That(modelFeature.UnsafeObject, Is.EqualTo(feature.Object));
        Assert.That(modelFeature.FeatureData, Is.Not.Null);
        Assert.That(modelFeature.FeatureData, Is.EqualTo(featureData.Object));
        Assert.That(modelFeature.SpecificFeature, Is.Not.Null);
        Assert.That(modelFeature.SpecificFeature, Is.EqualTo(specificFeature.Object));
        feature.Verify(x => x.GetSpecificFeature2(), Times.Once);
        feature.Verify(x => x.GetDefinition(), Times.Once);
    }
}