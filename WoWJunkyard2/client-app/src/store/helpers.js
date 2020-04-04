import {mapGetters} from 'vuex'

export const authenticatedComputed = {
    ...mapGetters(['loggedIn'])
}

export const usernameComputed = {
    ...mapGetters(['loggedInUser'])
}