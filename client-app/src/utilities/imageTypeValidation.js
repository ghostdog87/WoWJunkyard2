import { helpers } from 'vuelidate/lib/validators'

//TODO: make external vuelidate validation to work in future
const image_type_validation = (options = {}) => {
    return helpers.withParams(options, value => {
      if (options['type']==='image/jpeg' || options['type']==='image/png') {
          console.dir(value);
        return false;
      }
      return true;
    })
  }

export default image_type_validation;