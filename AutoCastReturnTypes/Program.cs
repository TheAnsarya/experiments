using System;

namespace AutoCastReturnTypes {
	class Program {
		static void Main(string[] args) {
			var exp = new Experiment();

			Widget w = exp.GetEntity();
			Doodad d = exp.GetEntity();
		}
	}

	class Experiment {
		public Doodad GetEntityAsDoodad() {
			return new Doodad();
		}

		public Widget GetEntityAsWidget() {
			return new Widget();
		}

		public class GetEntityAuto {
			private Experiment experiment;

			public GetEntityAuto(Experiment experiment) {
				this.experiment = experiment;
			}

			public static implicit operator Widget(GetEntityAuto value) {
				return value.experiment.GetEntityAsWidget();
			}

			public static implicit operator Doodad(GetEntityAuto value) {
				return value.experiment.GetEntityAsDoodad();
			}
		}

		public GetEntityAuto GetEntity() {
			return new GetEntityAuto(this);
		}
	}

	class Widget {
	}

	class Doodad {
	}
}
