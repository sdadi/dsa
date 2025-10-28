namespace _15Competitive {
        internal class Program {
        static void Main(string[] args) {
            Class1();
            //Class11();
            //Class13();
        }
        static void Class13() {
            var p = new _13SegmentTreeLazyPropagation();
            p.FlippingSign();

            Console.Read();
        }
        static void Class11() {
            var p = new _11SegmentTree();
            p.RangeMinimumQuery();

            Console.Read();
        }
        static void Class1() {

            _1ArticulationPointsBridges obj = new _1ArticulationPointsBridges();
            //obj.ArticulationPoints();

            obj.BridgesInGraph();
        }
    }
}
