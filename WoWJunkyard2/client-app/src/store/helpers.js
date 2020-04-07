import {mapGetters} from 'vuex'
import {mapState} from 'vuex'

export const authenticatedComputed = {
    ...mapGetters(['loggedIn'])
}

export const usernameComputed = {
    ...mapGetters(['loggedInUser'])
}

export const loadingComputed = {
    ...mapGetters(['isLoading'])
}

export const baseURL = {
    ...mapState(['$localAPI'])
}