import {mapGetters} from 'vuex'

export const authenticatedComputed = {
    ...mapGetters(['loggedIn'])
}