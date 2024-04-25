import {ChakraProvider} from '@chakra-ui/react'

import Router from './routes/index.tsx'

function App() {
	return (
		<>
			<ChakraProvider>
				<Router/>
			</ChakraProvider>
		</>
	)
}

export default App
