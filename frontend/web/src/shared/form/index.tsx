import TextField from "../ui/fields/TextField";
import withControlledField from "./withControlledField";

export const TextFieldControlled = withControlledField((props) => (
  <TextField {...props} />
));
