namespace Depski.Map {
	public class MapFactory {
		public static Map Create(int vertexCount = 80, float radius = 100, int smoothingIterations = 5, float roadDensity = .3f) {
			Generator generator = new Generator(vertexCount, radius, smoothingIterations, roadDensity);

			return generator.Generate();
		}
	}
}
